using System;
using System.Web.Configuration;
using App.Models;
using System.IO;
using System.Text;
using App.Common;

namespace App.BLL.Core
{

        /// <summary>
        /// 写入一个异常错误
        /// </summary>
        /// <param name="ex">异常</param>
        public static class ExceptionHander
        {
            /// <summary>
            /// 加入异常日志
            /// </summary>
            /// <param name="ex">异常</param>
            public static void WriteException(Exception ex)
            {
               
                    try
                    {
                        using (DB db = new DB())
                        {
                            SysException model = new SysException()
                            {
                                Id = ResultHelper.NewId,
                                HelpLink = ex.HelpLink,
                                Message = ex.Message,
                                Source = ex.Source,
                                StackTrace = ex.StackTrace,
                                TargetSite = ex.TargetSite.ToString(),
                                Data =ex.Data.ToString(),
                                CreateTime = ResultHelper.NowTime
                                
                            };
                            db.SysException.Add(model);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ep)
                    {
                        try
                        {
                            //异常失败写入txt
                            string logPath = System.AppDomain.CurrentDomain.BaseDirectory + "Log" + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                            if (!File.Exists(logPath))
                            {
                                using (System.IO.FileStream fs = System.IO.File.Create(logPath))
                                {
                                    fs.Close();
                                    fs.Dispose();
                                }
                            }
                            using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.UTF8))
                            {
                                sw.WriteLine((ex.Message + "|" + ex.StackTrace + "|" + ep.Message + "|" + DateTime.Now.ToString()).ToString());
                                sw.Dispose();
                                sw.Close();
                            }
                            return;
                        }
                        catch { return; }
                    }
            }
        }

    
}