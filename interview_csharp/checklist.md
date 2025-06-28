# Kế hoạch ôn tập phỏng vấn .NET - ITBee

## 📋 Phân tích JD
**Vị trí:** Thực tập sinh .NET  
**Công nghệ chính:** C#, .NET Core 7, ASP.NET, MVC, Entity Framework  
**Bonus:** ABP Framework  
**Soft skills:** Tinh thần học hỏi, teamwork

---

## 🎯 Kế hoạch ôn tập 1 ngày

### ⏰ Buổi sáng (3-4 tiếng)

#### 1. C# Fundamentals (1.5 tiếng)
- **OOP principles:** Encapsulation, Inheritance, Polymorphism, Abstraction
- **Access modifiers:** public, private, protected, internal
- **Data types & Collections:** Array, List, Dictionary, Stack, Queue
- **Exception handling:** try-catch-finally, custom exceptions
- **LINQ:** Where, Select, OrderBy, GroupBy

#### 2. .NET Core & ASP.NET (1.5 tiếng)
- **Middleware pipeline** và cách hoạt động
- **Dependency Injection** trong .NET Core
- **Configuration** (appsettings.json)
- **Controllers & Actions**
- **Routing** trong ASP.NET

### ⏰ Buổi chiều (3-4 tiếng)

#### 3. MVC Pattern (1 tiếng)
- **Model-View-Controller** architecture
- **Data flow** trong MVC
- **ViewModels** vs Models
- **Razor syntax** cơ bản

#### 4. Entity Framework (1.5 tiếng)
- **Code First vs Database First**
- **DbContext & DbSet**
- **Migrations** và cách sử dụng
- **CRUD operations**
- **Relationships:** One-to-One, One-to-Many, Many-to-Many

#### 5. Database & SQL (1 tiếng)
- **SQL cơ bản:** SELECT, INSERT, UPDATE, DELETE
- **JOINs:** INNER, LEFT, RIGHT
- **Indexes** và tối ưu query

### 🌆 Buổi tối (1-2 tiếng)

#### 6. Soft Skills & Company Research
- Tìm hiểu về **ITBee Solutions**
- Chuẩn bị câu trả lời về **động lực**, **mục tiêu**
- **ABP Framework** overview (nếu có thời gian)

---

## 🔥 Câu hỏi phỏng vấn thường gặp

### **C# & .NET Core**

**Q1: Sự khác biệt giữa .NET Framework và .NET Core?**
- .NET Framework: Windows-only, monolithic
- .NET Core: Cross-platform, modular, open-source, performance tốt hơn

**Q2: Dependency Injection là gì? Tại sao cần sử dụng?**
- Pattern để quản lý dependencies
- Giảm coupling, dễ test, dễ maintain
- Built-in trong .NET Core

**Q3: Middleware trong ASP.NET Core hoạt động như thế nào?**
- Pipeline xử lý request/response
- Thứ tự quan trọng (authentication → authorization → routing)
- Configure trong Program.cs (NET 6+)

**Q4: So sánh IEnumerable và IQueryable?**
- IEnumerable: In-memory, execute ngay
- IQueryable: Database level, lazy evaluation, có thể optimize

### **Entity Framework**

**Q5: Code First vs Database First?**
- Code First: Tạo database từ code (models)
- Database First: Generate models từ database có sẵn
- Code First linh hoạt hơn, dễ version control

**Q6: Migration là gì? Cách sử dụng?**
```bash
# Tạo migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

**Q7: Lazy Loading vs Eager Loading?**
- Lazy: Load data khi cần (Include())
- Eager: Load tất cả data ngay từ đầu
- Cần cân nhắc performance

### **MVC & Web Development**

**Q8: MVC pattern hoạt động như thế nào?**
- Model: Data & business logic
- View: UI presentation
- Controller: Handle requests, coordinate Model-View

**Q9: ViewBag vs ViewData vs TempData?**
- ViewBag: Dynamic, type-unsafe
- ViewData: Dictionary, type-unsafe  
- TempData: Persist qua redirect, session-based

**Q10: Cách handle validation trong ASP.NET MVC?**
- Data Annotations: [Required], [Range], [Email]
- ModelState.IsValid check
- Client-side validation với jQuery

### **Database & Performance**

**Q11: SQL Injection và cách prevent?**
- Parameterized queries
- Entity Framework tự động prevent
- Không concatenate string trực tiếp

**Q12: Index trong database là gì?**
- Cải thiện query performance
- Trade-off: Faster read, slower write
- Clustered vs Non-clustered

### **Soft Skills & Tình huống**

**Q13: Tại sao muốn làm thực tập tại ITBee?**
- Được học từ mentor có kinh nghiệm
- Tham gia dự án thực tế
- Môi trường friendly, cơ hội phát triển

**Q14: Làm thế nào debug khi gặp lỗi?**
- Đọc error message carefully
- Sử dụng debugger, breakpoints
- Check logs, search Stack Overflow
- Hỏi mentor/team members

**Q15: Conflict trong team xử lý như thế nào?**
- Lắng nghe ý kiến của mọi người
- Tìm solution win-win
- Focus vào technical solution, không cá nhân hóa

---

## 🚀 Tips phỏng vấn

### **Trước phỏng vấn**
- ✅ Test setup môi trường (Visual Studio, .NET SDK)
- ✅ Chuẩn bị laptop, có thể code demo nhỏ
- ✅ In CV, portfolio nếu có
- ✅ Tìm hiểu route đến công ty

### **Trong phỏng vấn**
- 💡 **Thành thật:** Nếu không biết, nói "Em chưa có kinh nghiệm với X, nhưng em sẵn sàng học"
- 💡 **Hỏi lại:** Show interest bằng cách hỏi về tech stack, dự án
- 💡 **Concrete examples:** Đưa ví dụ cụ thể từ học tập/project
- 💡 **Growth mindset:** Nhấn mạnh khả năng học hỏi

### **Câu hỏi nên hỏi ngược**
- "Anh/chị có thể chia sẻ về dự án em sẽ tham gia không?"
- "Tech stack chính của công ty là gì?"
- "Mentor sẽ support em như thế nào?"
- "Roadmap phát triển cho thực tập sinh ra sao?"

---

## 📚 Tài liệu tham khảo nhanh

- **Microsoft Docs:** docs.microsoft.com/dotnet
- **Entity Framework:** docs.microsoft.com/ef
- **ASP.NET Core:** docs.microsoft.com/aspnet/core
- **C# Programming Guide:** docs.microsoft.com/dotnet/csharp

---

## ✨ Lời khuyên cuối

Đây là vị trí **thực tập sinh**, họ tìm người có **potential** chứ không phải expert. Quan trọng nhất là thể hiện:
- 🔥 **Passion** cho lập trình
- 🧠 **Khả năng học hỏi** nhanh
- 🤝 **Teamwork** tốt
- 💪 **Commitment** với công việc

**Good luck! 🍀**