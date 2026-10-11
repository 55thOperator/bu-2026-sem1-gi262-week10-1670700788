using System;
using System.Collections.Generic;

namespace MidtermExam.Prob02
{
    /// <summary>
    /// โค้ดที่เตรียมให้: แยกข้อความคำสั่งแล้วเรียกเมธอดของ StudentWebBrowser
    /// นักศึกษาไม่ต้องแก้ไขไฟล์นี้ ให้เขียนระบบประวัติใน StudentWebBrowser.cs
    /// </summary>
    public class BrowserNavigation
    {
        /// <summary>ประมวลผลคำสั่งที่คั่นด้วย ; โดยสร้าง browser ใหม่ทุกครั้งที่เรียก</summary>
        /// <param name="actions">
        /// รองรับ open ตามด้วย URL, back, forward และ current โดยแยกตัวพิมพ์เล็ก/ใหญ่
        /// ตัดช่องว่างรอบคำสั่งและ URL ให้แล้ว คำสั่งที่ไม่รู้จักจะถูกข้าม
        /// </param>
        /// <returns>
        /// array ของ URL ที่ได้จากคำสั่ง current ตามลำดับ หนึ่งคำสั่งต่อหนึ่งผลลัพธ์
        /// ถ้า actions เป็น null/ว่าง/ช่องว่างล้วน หรือไม่มี current จะคืน array ว่าง
        /// </returns>
        /// <remarks>ตัวอย่าง: "current; open a; current" ได้ผลลัพธ์ ["", "a"]</remarks>
        public string[] AS02_WebBrowserNavigation(string actions)
        {
            var browser = new StudentWebBrowser();
            // List นี้เก็บผลลัพธ์ของ parser เท่านั้น ประวัติการนำทางต้องเก็บด้วย Stack ในอีกคลาส
            var output = new List<string>();
            if (string.IsNullOrWhiteSpace(actions)) return output.ToArray();

            foreach (string part in actions.Split(';'))
            {
                // แยกและเรียกคำสั่งให้แล้ว จึงไม่ต้องเขียนส่วนจัดการข้อความในคำตอบของนักศึกษา
                string command = part.Trim();
                if (command.StartsWith("open ", StringComparison.Ordinal))
                    browser.Open(command.Substring(5).Trim());
                else if (command == "back") browser.Back();
                else if (command == "forward") browser.Forward();
                else if (command == "current") output.Add(browser.Current());
            }
            return output.ToArray();
        }
    }
}
