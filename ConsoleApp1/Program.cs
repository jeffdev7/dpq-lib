using DPQ.lib.Services;


MaskingService _mask = new MaskingService();

string cpf = "444.680.972-91";
string cardNumber = "4465 1098 9999 1120";
var test = _mask.Mask(cpf, "CPF", DPQ.lib.Enums.MaskingLevel.Partial);
var test2 = _mask.Mask(cardNumber, "CreditCard", DPQ.lib.Enums.MaskingLevel.Partial);
var test3 = _mask.Mask(cardNumber, "CreditCard", DPQ.lib.Enums.MaskingLevel.Encrypted);

Console.WriteLine("======== TESTING ====");
Console.WriteLine($"CPF: {cpf}");
Console.WriteLine($"CPF with mask: {test}\n");

Console.WriteLine($"cardNumber number: {cardNumber}");
Console.WriteLine($"cardNumber with mask: {test2}\n");
Console.WriteLine($"cardNumber encrypted: {test3}\n");


Console.ReadLine();






