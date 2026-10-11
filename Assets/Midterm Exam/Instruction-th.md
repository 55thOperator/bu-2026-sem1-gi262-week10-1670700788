# ข้อสอบกลางภาค ครั้งที่ 2 - GI262

ภาคการศึกษา 1/2026 | มหาวิทยาลัยกรุงเทพ

หัวข้อ: Queue, Stack, Binary Tree, Recursion, Sequential Search และ Binary Search

คะแนนรวม 100 คะแนน มี 4 ข้อใหญ่ เวลาและกำหนดส่งให้ยึดตามที่อาจารย์ประกาศ

| ข้อ | หัวข้อ | โฟลเดอร์ | คะแนน |
| --- | --- | --- | ---: |
| 01 | นับสระด้วย Queue และรักษาลำดับข้อมูล | `Prob01-VowelQueue` | 20 |
| 02 | จำลอง Browser ด้วย Stack 2 ชุด | `Prob02-BrowserStack` | 30 |
| 03 | นับโหนด Binary Tree ด้วย Recursion | `Prob03-RecursiveTree` | 30 |
| 04 | Sequential Search และ Binary Search | `Prob04-Search` | 20 |

ทุกโฟลเดอร์อยู่ใต้ `Assets/Midterm Exam/` แต่ละข้อทำแยกจากกันได้ ไม่ต้องสร้าง Scene, GameObject หรือ UI

## วิธีเริ่มทำและส่งงาน

1. เปิดโปรเจกต์ด้วย Unity เวอร์ชันที่ระบุใน `ProjectSettings/ProjectVersion.txt` (6000.5.5f1)
2. อ่านคอมเมนต์ภาษาไทยเหนือแต่ละเมธอด เพื่อดูข้อมูลนำเข้า ผลลัพธ์ และกรณีที่ต้องจัดการ แล้วแก้ไขส่วน TODO ใน `VowelCounter.cs`, `StudentWebBrowser.cs`, `TreeCounter.cs` และ `NumberSearch.cs` เพิ่ม private helper method ได้
3. คงชื่อคลาส, namespace, ชื่อเมธอด, parameter และ return type ตามไฟล์เริ่มต้น
4. เปิด `Window > General > Test Runner` เลือก `EditMode` แล้วกด `Run All` เพื่อดูผล ไม่ต้องกด Play
5. ไฟล์เริ่มต้นตั้งใจให้ compile ได้ แต่เมธอด TODO จะโยน `NotImplementedException` จึงยังไม่ผ่านการทดสอบ ให้แทนที่คำสั่งนั้นด้วยคำตอบ
6. ส่งโปรเจกต์ที่มี `Assets`, `Packages` และ `ProjectSettings` ตามช่องทางที่อาจารย์กำหนด ไม่ต้องส่ง `Library`, `Temp`, `Logs`, `obj` หรือ `tmp`

ห้ามแก้ไขไฟล์ใน `Tests/`, ไฟล์ `.asmdef`, `BrowserNavigation.cs` และ `Node.cs` เพื่อเปลี่ยนผลการตรวจ สำหรับข้อการค้นหา ห้ามใช้ LINQ, `Array.IndexOf`, `Array.BinarySearch`, `List.Find`, `Contains` หรือเมธอดค้นหาสำเร็จรูปแทนอัลกอริทึมที่ให้เขียน

คะแนนพิจารณาทั้งผลลัพธ์และการใช้โครงสร้างข้อมูล/อัลกอริทึมตามข้อกำหนด การผ่าน Test อย่างเดียวไม่ได้ยืนยันว่าใช้ Queue, Stack, Recursion หรือ Binary Search ถูกวิธี

## ข้อ 01: AS01_CountVowels - Queue (20 คะแนน)

ไฟล์ `Prob01-VowelQueue/VowelCounter.cs` | namespace `MidtermExam.Prob01`

```csharp
public int AS01_CountVowels(Queue<string> alphabets)
```

รับคิวตัวอักษรแล้วคืนจำนวนสมาชิกที่เป็นสระภาษาอังกฤษตัวพิมพ์เล็ก `"a"`, `"e"`, `"i"`, `"o"`, `"u"` นับตัวซ้ำทุกตัว สมาชิกอื่น เช่น `"A"`, `"ae"`, `""` หรือ `null` ไม่นับเป็นสระ

Queue ใช้หลัก **FIFO (First In, First Out)**: สมาชิกที่เข้าก่อนออกก่อน เมื่อเมธอดจบ ตัวแปร `alphabets` ที่รับมาต้องยังคงข้อมูลเหมือนเดิมทั้งจำนวนสมาชิก ค่า และลำดับ ถ้าคิวเป็น `null` หรือว่าง ให้คืน `0`

**คำใบ้:** สามารถอ่านสมาชิกหัวคิวด้วย `Dequeue()` และใส่สมาชิกเดิมกลับท้ายคิวด้วย `Enqueue()` ในคิวที่รับมา

ลำดับตัวอย่างด้านล่างอ่านจากหัวคิวไปท้ายคิว:

| Input | Return | คิวหลังเรียก |
| --- | ---: | --- |
| `[]` | 0 | `[]` |
| `["a"]` | 1 | `["a"]` |
| `["a","e","i","o","u"]` | 5 | เหมือนเดิม |
| `["a","b","e","c","i","d","o","u"]` | 5 | เหมือนเดิม |
| `["b","c","d","f"]` | 0 | เหมือนเดิม |
| `["a","a","a","e","e"]` | 5 | เหมือนเดิม |
| `["a","b","e","a"]` | 3 | `["a","b","e","a"]` |
| `["A",null,"ae",""," ","u"]` | 1 | เหมือนเดิม |
| `null` | 0 | `null` |

ให้เรียกเมธอดซ้ำกับคิวเดิมแล้วได้ผลเท่าเดิม ห้ามทำให้สมาชิกหายหรือคิวหมุนค้าง

## ข้อ 02: AS02_WebBrowserNavigation - Stack (30 คะแนน)

ไฟล์ที่ต้องทำ `Prob02-BrowserStack/StudentWebBrowser.cs` | namespace `MidtermExam.Prob02`

จำลองการเปิดเว็บโดยใช้ Stack ตามหลัก **LIFO (Last In, First Out)**: สมาชิกที่ใส่ล่าสุดถูกนำออกก่อน ใช้ `Stack<string>` ที่เตรียมให้ 2 ชุด และตัวแปรเก็บหน้าปัจจุบันดังนี้:

| ตัวแปร | หน้าที่ |
| --- | --- |
| `backHistory` | เก็บประวัติย้อนกลับ หน้าบนสุดคือหน้าที่ `Back()` จะเปิดถัดไป |
| `forwardHistory` | เก็บประวัติไปข้างหน้า (redo stack) หน้าบนสุดคือหน้าที่ `Forward()` จะเปิดถัดไป |
| `currentUrl` | เก็บหน้าปัจจุบันแยกจากทั้งสอง Stack เริ่มต้นเป็น `string.Empty` หมายถึงยังไม่เคยเปิดเว็บ |

| เมธอด | พฤติกรรม |
| --- | --- |
| `void Open(string url)` | เก็บหน้าปัจจุบันใน back history ถ้ามีหน้าเปิดอยู่ ตั้งหน้าปัจจุบันเป็น URL ใหม่ และล้าง forward history |
| `void Back()` | ถ้ามี back history ให้เก็บหน้าปัจจุบันใน forward history แล้วกลับไปหน้าบนสุดของ back history |
| `void Forward()` | ถ้ามี forward history ให้เก็บหน้าปัจจุบันใน back history แล้วไปหน้าบนสุดของ forward history |
| `string Current()` | คืน URL ปัจจุบันโดยไม่เปลี่ยนหน้าหรือประวัติ ถ้าไม่เคยเปิดเว็บ คืน `string.Empty` |

ถ้าไม่มีประวัติในทิศทางนั้น `Back()`/`Forward()` ต้องไม่เปลี่ยนสถานะและไม่เกิด exception `Open(null)`, `Open("")` และ URL ที่เป็นช่องว่างล้วนต้องไม่มีผลต่อทั้งหน้าปัจจุบันและประวัติ สำหรับ URL ที่ใช้ได้ให้เก็บข้อความตามที่รับมา ไม่ต้องตัดช่องว่างใน `Open()` แม้เปิด URL เดิมก็ถือเป็นการเปิดหน้าใหม่และต้องล้าง forward history

ใช้ `Push`, `Pop`, `Peek`, `Count`, `Clear` ของ Stack ตามความเหมาะสม ห้ามใช้ List, array หรือ collection อื่นแทนประวัติ

ไฟล์ `BrowserNavigation.cs` เตรียม parser ให้แล้ว:

```csharp
public string[] AS02_WebBrowserNavigation(string actions)
```

ใช้ `;` คั่นคำสั่ง `open <url>`, `back`, `forward`, `current` โดยแยกตัวพิมพ์เล็ก/ใหญ่ parser จะตัดช่องว่างรอบคำสั่งและ URL และสร้าง browser ใหม่ทุกครั้งที่เรียก คืน array ของ URL เฉพาะจุดที่สั่ง `current` ตามลำดับ หนึ่งคำสั่งต่อหนึ่งผลลัพธ์ ถ้า actions เป็น `null`/ว่าง/ช่องว่างล้วน หรือไม่มีคำสั่ง `current` คืน array ว่าง คำสั่งไม่รู้จักจะถูกข้าม ไม่ต้องเขียน parser เอง

`List<string>` ใน parser ใช้เก็บผลลัพธ์ของคำสั่ง `current` เท่านั้น ส่วนประวัติการนำทางที่นักศึกษาต้องทำใน `StudentWebBrowser` ให้เก็บด้วย Stack ตามโจทย์

| actions | Return |
| --- | --- |
| `open google.com; current` | `["google.com"]` |
| `open google.com; open youtube.com; back; current` | `["google.com"]` |
| `back; current` | `[""]` |
| `open google.com; open youtube.com; back; forward; current` | `["youtube.com"]` |
| `open google.com; forward; current` | `["google.com"]` |
| `open google.com; open youtube.com; open github.com; back; back; forward; current` | `["youtube.com"]` |
| `open a; open b; back; open c; forward; current` | `["c"]` |
| `current; open a; current; open b; back; current` | `["","a","a"]` |
| `current; open a; current` | `["","a"]` |
| `open a; back` | `[]` |

## ข้อ 03: AS03_CountTotalNode - Tree และ Recursion (30 คะแนน)

ไฟล์ `Prob03-RecursiveTree/TreeCounter.cs` | namespace `MidtermExam.Prob03`

```csharp
public int AS03_CountTotalNode(Node root)
```

คืนจำนวนโหนดทั้งหมดใน Binary Tree รวมโหนดราก (`root`) โดยใช้ฟังก์ชันเรียกซ้ำ (Recursion) ที่สำรวจทั้งต้นไม้ย่อยซ้ายและขวา ถ้า `root` เป็น `null` ให้คืน `0` ต้องนับทุกโหนดโดยไม่ขึ้นกับค่า `value` แม้ค่าซ้ำกันก็ต้องนับเป็นคนละโหนด และห้ามเปลี่ยนค่าหรือการเชื่อมต่อของโหนด

`Node.cs` เตรียม `public int value`, `public Node left`, `public Node right` และ constructor `Node(int value, Node left = null, Node right = null)` ให้แล้ว ต้นไม้ไม่จำเป็นต้องเป็น Binary Search Tree ค่าซ้ำกันได้และแต่ละโหนดต้องนับแยกกัน ข้อมูลเป็นต้นไม้จำกัดขนาด ไม่มี cycle และไม่มี child ที่หลาย parent ใช้ร่วมกัน

### โหนดและขอบเชื่อมของ Binary Tree

ตัวอย่าง `new Node(1, new Node(2), new Node(3))` มีทั้งหมด 3 โหนด:

```text
                       [1]  <-- node (root)
                      /   \
          left edge  /     \  right edge
                    /       \
                  [2]       [3]
                 left       right
```

| ส่วนประกอบ | ความหมาย |
| --- | --- |
| `[1]`, `[2]`, `[3]` | โหนดแต่ละตัว ตัวเลขในวงเล็บคือค่า `value` ซึ่งไม่ใช่จำนวนโหนดในต้นไม้ย่อย |
| เส้น `/` (left edge) | ขอบเชื่อมไปลูกซ้าย แทนด้วย reference ในฟิลด์ `left`; ตัวอย่างนี้ `root.left` อ้างถึงโหนด `[2]` |
| เส้น `\` (right edge) | ขอบเชื่อมไปลูกขวา แทนด้วย reference ในฟิลด์ `right`; ตัวอย่างนี้ `root.right` อ้างถึงโหนด `[3]` |
| โหนดใบ (leaf) | โหนดที่ไม่มีลูก เช่น `[2]` และ `[3]` ในรูป มี `left` และ `right` เป็น `null` ทั้งคู่ |

ถ้าใช้ `new Node(1)` โดยไม่ระบุลูก จะได้โหนดเดี่ยวที่มี `left` และ `right` เป็น `null` และเมื่อนับโหนดต้องคืน `1`

### ตัวอย่างผลลัพธ์

| รูปร่างต้นไม้ | Return |
| --- | ---: |
| `null` | 0 |
| root เดี่ยว | 1 |
| root มีลูกซ้ายตัวเดียว | 2 |
| root มีลูกขวาตัวเดียว | 2 |
| root มีลูกซ้ายและขวา | 3 |
| root 1, ลูก 2/3, โหนด 2 มีลูก 4/5 | 5 |
| โหนดต่อกันทางซ้าย 4 ตัว | 4 |
| โหนดต่อกันทางขวา 4 ตัว | 4 |
| ต้นไม้ตามรูปด้านล่าง | 8 |

```text
        1
      /   \
     2     3
    / \   / \
   4   5 6   7
  /
 8
```

## ข้อ 04: การค้นหา - Sequential และ Binary Search (20 คะแนน)

ไฟล์ `Prob04-Search/NumberSearch.cs` | namespace `MidtermExam.Prob04`

### 04.1 Sequential Search (10 คะแนน)

```csharp
public int AS04_SequentialSearch(int[] values, int target)
```

ค้นหา `target` จาก array ที่อาจไม่เรียงลำดับ มีค่าซ้ำหรือตัวเลขติดลบได้ โดยตรวจจากต้น array ไปท้าย array คืน index แรกที่พบ (เริ่มนับจาก 0) ถ้าไม่พบหรือ input เป็น `null`/array ว่าง คืน `-1` เขียน Sequential Search เอง ใช้เวลา O(n) ห้ามแก้ไขหรือเรียง array และห้ามใช้เมธอดค้นหาสำเร็จรูปหรือ LINQ

| values | target | Return |
| --- | ---: | ---: |
| `[34,21,56,12,78,90,11,23]` | 90 | 5 |
| `[4,2,4,1]` | 4 | 0 |
| `[-3,0,9]` | 0 | 1 |
| `[1,2,3]` | 7 | -1 |
| `[]` หรือ `null` | 1 | -1 |

### 04.2 Binary Search (10 คะแนน)

```csharp
public int AS05_BinarySearch(int[] sortedValues, int target)
```

ค้นหา `target` จาก array ที่เรียงจากน้อยไปมากให้แล้ว มีค่าซ้ำหรือตัวเลขติดลบได้ ต้องลดช่วงค้นหาประมาณครึ่งหนึ่งในแต่ละขั้น ใช้เวลา O(log n) ใช้ลูปหรือ recursion ได้ แต่ห้ามค้นหาแบบไล่ทุกสมาชิกหรือเรียกเมธอดค้นหาสำเร็จรูป คืน index ที่พบ ถ้ามีค่าซ้ำ คืน index ใดก็ได้ที่มีค่าเท่ากับ target โดยไม่จำเป็นต้องเป็น index แรก ถ้าไม่พบหรือ input เป็น `null`/array ว่าง คืน `-1` ห้ามแก้ไข array และไม่ต้องตรวจหรือจัดเรียง input ใหม่

**แนวทาง:** กำหนดขอบเขตของช่วงค้นหา เปรียบเทียบค่าตรงกลางกับ `target` แล้วเลือกค้นหาต่อเฉพาะครึ่งซ้ายหรือครึ่งขวา โดยตัดตำแหน่งที่ตรวจแล้วออกเพื่อให้ช่วงเล็กลงทุกครั้ง ลองตรวจกรณีสมาชิกเดียว สองสมาชิก เป้าหมายอยู่หัว/ท้าย และเป้าหมายอยู่นอกช่วงค่า

| sortedValues | target | Return |
| --- | ---: | --- |
| `[11,12,21,23,34,45,56,78,90]` | 23 | 3 |
| `[1,2,2,2,5]` | 2 | 1, 2 หรือ 3 |
| `[-10,-3,0,9]` | -10 | 0 |
| `[1,3,5]` | 4 | -1 |
| `[7]` | 7 | 0 |
| `[]` หรือ `null` | 1 | -1 |

เขียนคอมเมนต์สั้น ๆ เหนือคำตอบของแต่ละเมธอดในข้อนี้ อธิบายเหตุผลของเวลา O(n) และ O(log n)

## เกณฑ์คะแนนย่อ

| ข้อ | ผลลัพธ์และกรณีขอบเขต | วิธีที่ใช้ | รวม |
| --- | ---: | ---: | ---: |
| Queue | นับและคงสมาชิก/ลำดับ 14 | ประยุกต์ใช้ Queue ตามหลัก FIFO 6 | 20 |
| Stack | การนำทางและกรณีขอบเขต 22 | ใช้ Stack 2 ชุดและรักษาประวัติ 8 | 30 |
| Tree | ผลการนับและคงต้นไม้ 18 | recursion, base case และสำรวจทั้งสองฝั่ง 12 | 30 |
| Search | ผลการค้นหา 12 | อัลกอริทึม, complexity และคำอธิบาย 8 | 20 |

Test Cases ที่ให้ช่วยตรวจพฤติกรรม อาจารย์จะตรวจ source code เพิ่มสำหรับข้อกำหนดเรื่องโครงสร้างข้อมูลและวิธีแก้ปัญหา
