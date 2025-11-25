# dpq-lib
<p>A simple modern library for masking sensitive data.</p>
<p>It can be also used for Data Mesh architecture with automatic sensitive data masking, ensuring GDPR/LGPD compliance.</p>

### 📦 Installing the package
<pre><code>
dotnet add package DPQ.lib
</code></pre>

### 🚀 Quick start
<pre><code>
using DPQ.lib;

var mask = new MaskingService();
string cpf = "123.456.789-01";
var masked = mask.Mask(cpf, "CPF", MaskingLevel.Partial);

Console.WriteLine(masked); // Output: ***.***.***.01
</code></pre>

### 📖 Simple usage
<pre><code>
  var mask = new MaskingService();

// CPF (Brazilian Tax ID)
mask.Mask("123.456.789-01", "CPF", MaskingLevel.Partial);
// Output: ***.***.***.01

// Email
mask.Mask("john@email.com", "Email", MaskingLevel.Partial);
// Output: j***n@email.com

// Phone
mask.Mask("(11) 98765-4321", "Phone", MaskingLevel.Partial);
// Output: (11) ****-4321

// Credit Card
mask.Mask("1234 5678 9012 3456", "CreditCard", MaskingLevel.Partial);
// Output: **** **** **** 3456
</code></pre>

### 📋 Features

✅ Ready-to-use strategies: CPF, Email, Phone, Credit Card

✅ 4 masking levels: None, Partial, Full, Encrypted

✅ Data Mesh architecture: Decentralized data products

✅ Extensible: Create custom masking strategies

✅ GDPR/LGPD compliant: Built-in data protection


| Level | Description | Example |
|-------|-------------|---------|
| `None` | No masking | `123.456.789-01` |
| `Partial` | Shows last digits | `***.***.***.01` |
| `Full` | Fully masked | `***.***.***-**` |
| `Encrypted` | AES-256 encrypted | `Base64String` |

### 🛠️ Requirements

.NET 8.0+ No external dependencies
