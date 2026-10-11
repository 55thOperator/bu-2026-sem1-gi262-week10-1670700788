namespace MidtermExam.Prob03
{
    /// <summary>
    /// โค้ดที่เตรียมให้: โหนดของ Binary Tree ซึ่งมีลูกได้สูงสุดสองโหนด
    /// ค่าของโหนดไม่จำเป็นต้องเรียงแบบ Binary Search Tree และมีค่าซ้ำกันได้
    /// ข้อมูลทดสอบเป็นต้นไม้ที่ไม่มีวงวนและไม่มีโหนดลูกที่หลาย parent ใช้ร่วมกัน
    /// นักศึกษาไม่ต้องแก้ไขคลาสนี้
    /// </summary>
    public class Node
    {
        // ตัวอย่าง Binary Tree: new Node(1, new Node(2), new Node(3))
        //
        //                       [1]  <-- node (root)
        //                      /   \
        //          left edge  /     \  right edge
        //                    /       \
        //                  [2]       [3]
        //                 left       right
        //
        // [1], [2], [3] คือโหนด (Node) แต่ละโหนดมี value เป็นค่าที่แสดงในวงเล็บ
        // เส้น / คือขอบเชื่อมไปลูกซ้าย (left edge) แทนด้วย reference ในฟิลด์ left
        // เส้น \ คือขอบเชื่อมไปลูกขวา (right edge) แทนด้วย reference ในฟิลด์ right
        // ในตัวอย่าง root.left อ้างถึงโหนด [2] และ root.right อ้างถึงโหนด [3]
        // โหนด [2] และ [3] เป็นโหนดใบ (leaf): left และ right เป็น null ทั้งคู่

        // ข้อมูลที่เก็บในโหนด ค่านี้ไม่ใช่จำนวนโหนดของต้นไม้ย่อย
        public int value;
        // ลูกซ้ายและลูกขวาเป็น null ได้ หมายถึงไม่มีลูกในฝั่งนั้น
        public Node left;
        public Node right;

        /// <summary>
        /// สร้างโหนดพร้อมลูกที่ระบุ เช่น new Node(1, new Node(2), new Node(3)) มีทั้งหมด 3 โหนด
        /// ถ้าไม่ระบุลูก จะสร้างโหนดเดี่ยวที่ left และ right เป็น null
        /// </summary>
        public Node(int value, Node left = null, Node right = null)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }
}
