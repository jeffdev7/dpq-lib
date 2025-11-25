# DPQ 

📋 Features

✅ Ready-to-use strategies: CPF, Email, Phone, Credit Card

✅ 4 masking levels: None, Partial, Full, Encrypted

✅ Data Mesh architecture: Decentralized data products

✅ Extensible: Create custom masking strategies

✅ GDPR/LGPD compliant: Built-in data protection


🚀 Quick start
using DPQ.Core;

var mask = new MaskingService();
string cpf = "123.456.789-01";
var masked = mask.Mask(cpf, "CPF", MaskingLevel.Partial);

Console.WriteLine(masked); // Output: ***.***.***.01


| Level | Description | Example |
|-------|-------------|---------|
| `None` | No masking | `123.456.789-01` |
| `Partial` | Shows last digits | `***.***.***.01` |
| `Full` | Fully masked | `***.***.***-**` |
| `Encrypted` | AES-256 encrypted | `Base64String` |

🛠️ Requirements

.NET 8.0+ No external dependencies
