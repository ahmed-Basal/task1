# Products API - API Versioning Demo (ASP.NET Core)

تطبيق ويب مبني باستخدام **ASP.NET Core Web API** يطبق **API Versioning** مع الحفاظ على التوافق مع الإصدارات السابقة (Backward Compatibility) دون التأثير على العملاء الحاليين.

---

## 🎯 المتطلبات المنفذة (Task 1)

1. **إعداد API Versioning في المشروع**:
   - استخدام مكتبة `Asp.Versioning.Mvc` و `Asp.Versioning.Mvc.ApiExplorer`.
   - دعم قراءة الإصدار من خلال:
     - مسار الرابط (URL Segment): `/api/v1/...` و `/api/v2/...`
     - الـ Query String: `?api-version=1.0`
     - الـ Header: `X-Version: 1.0`
   - إرجاع هيدر الإصدارات المدعومة تلقائياً: `api-supported-versions: 1.0, 2.0`.

2. **إنشاء `GET /api/v1/products` (الإصدار القديم)**:
   - يرجع مصفوفة المنتجات بالشكل المسطح القديم (`id`, `name`, `price`).

3. **إنشاء `GET /api/v2/products` (الإصدار الجديد)**:
   - يرجع استجابة مغلفة (Envelope Response) مع إضافة `categoryName`, `inStock`, `description` والبيانات الوصفية (`success`, `apiVersion`, `totalCount`, `data`).

4. **التأكد إن الإصدارين بيشتغلوا بشكل مستقل**:
   - وحدة تحكم منفصلة لكل إصدار: `Controllers/V1/ProductsController.cs` و `Controllers/V2/ProductsController.cs`.
   - توثيق تفاعلي كامل على **Swagger UI** و **Scalar**.

---

## 🚀 تشغيل المشروع

من خلال Terminal في مسار المشروع:

```bash
dotnet run
```

سيعمل الخادم على:

- `http://localhost:5211`

---

## 📖 واجهة التوثيق التفاعلية (Swagger UI & Scalar)

### 1. واجهة Swagger UI

افتح المتصفح على:

```text
http://localhost:5211/swagger/index.html
```

يمكنك التبديل بين `v1` و `v2` من القائمة المنسدلة في أعلى يمين صفحة Swagger.

### 2. واجهة Scalar API Reference (الحديثة)

تمت إضافة مكتبة **Scalar.AspNetCore** لتقديم واجهة توثيق عصرية مع Theme مميز:

- واجهة Scalar العامة:
  `http://localhost:5211/scalar`
- توثيق الإصدار الأول (V1):
  `http://localhost:5211/scalar/v1`
- توثيق الإصدار الثاني (V2):
  `http://localhost:5211/scalar/v2`

---

## 🧪 الـ Endpoints وتنسيق البيانات

### 1. الإصدار الأول (V1)

- **الرابط**: `GET http://localhost:5211/api/v1/products`
- **الشكل العائد (Array)**:

```json
[
  {
    "id": 1,
    "name": "Laptop Dell XPS",
    "price": 1500.00
  },
  {
    "id": 2,
    "name": "iPhone 15 Pro",
    "price": 1200.00
  }
]
```

---

### 2. الإصدار الثاني (V2)

- **الرابط**: `GET http://localhost:5211/api/v2/products`
- **الشكل العائد (Wrapped Object مع CategoryName)**:

```json
{
  "success": true,
  "apiVersion": "2.0",
  "message": "Products retrieved successfully in V2 format.",
  "totalCount": 4,
  "data": [
    {
      "id": 1,
      "name": "Laptop Dell XPS 15",
      "price": 1500.00,
      "categoryName": "Computers & Laptops",
      "inStock": true,
      "description": "15-inch display, Intel Core i7 processor, 32GB RAM, 1TB SSD"
    },
    {
      "id": 2,
      "name": "iPhone 15 Pro Max",
      "price": 1200.00,
      "categoryName": "Smartphones",
      "inStock": true,
      "description": "Titanium design with A17 Pro chip and advanced camera system"
    }
  ]
}
```

---

## 📁 هيكل المشروع

```text
ApiVersioningDemo/
├── Controllers/
│   ├── V1/
│   │   └── ProductsController.cs
│   └── V2/
│       └── ProductsController.cs
├── Models/
│   ├── V1/
│   │   └── ProductV1.cs
│   └── V2/
│       ├── ProductV2.cs
│       └── ApiResponseV2.cs
├── ConfigureSwaggerOptions.cs
├── Program.cs
├── ApiVersioningDemo.csproj
├── ApiVersioningDemo.http
└── README.md
```
