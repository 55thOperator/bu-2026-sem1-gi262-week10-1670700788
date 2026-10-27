using System;
using System.Collections.Generic;

namespace MidtermExam.Prob01
{
    public class VowelCounter
    {
        /// <summary>
        /// ข้อ 01: นับจำนวนสระภาษาอังกฤษตัวพิมพ์เล็กในคิว โดยใช้หลัก FIFO
        /// (สมาชิกที่เข้าก่อนออกก่อน) และรักษาสมาชิกกับลำดับของคิวเดิม
        /// </summary>
        /// <param name="alphabets">
        /// คิวข้อความที่ต้องการตรวจ นับเฉพาะ "a", "e", "i", "o", "u" และนับตัวซ้ำทุกตัว
        /// ข้อความอื่น เช่น "A", "ae", ข้อความว่าง และสมาชิก null ไม่นับเป็นสระ
        /// </param>
        /// <returns>จำนวนสระทั้งหมด หรือ 0 เมื่อคิวเป็น null หรือไม่มีสมาชิก</returns>
        /// <remarks>
        /// ตัวแปร Queue<string> alphabets หลังจากจบ function จะต้องยังคงข้อมูลให้เหมือนเดิมทั้งจำนวนและลำดับ
        /// HINT: อ่านข้อมูลด้วย Dequeue() และใส่กลับด้วย Enqueue() ในคิวที่รับมา
        /// ตัวอย่าง: ["a", "b", "e", "a"] จะต้อง return 3 
        /// และคิวหลังเรียกยังเป็น ["a", "b", "e", "a"] เหมือนเดิม
        /// </remarks>
        public int AS01_CountVowels(Queue<string> alphabets)
        {
            // TODO: เขียนคำตอบแทนคำสั่ง throw exception ด้านล่าง
            if (alphabets == null || alphabets.Count == 0)
            {
                return 0; 
            }

            int vowelCount = 0;
            var tempQueue = new Queue<string>();

            while (alphabets.Count > 0)
            {
                string current = alphabets.Dequeue();
                tempQueue.Enqueue(current);

                if (current == "a" || current == "e" || current == "i" || current == "o" || current == "u")
                {
                    vowelCount++;
                }
            }

            
            foreach (string item in tempQueue)
            {
                alphabets.Enqueue(item);
            }

            return vowelCount;
        }
    }
}
