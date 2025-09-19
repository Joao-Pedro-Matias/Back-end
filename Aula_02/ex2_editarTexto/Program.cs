TextEditor text1 = new TextEditor("1º Texto");

Console.Write(text1.Open());

text1.Edit("Andrezão gosta ");

Console.Write(text1.Open());

text1.Edit("de programar em C#");

Console.Write(text1.Open());

text1.Rename("Dúvida");

text1.Edit("?");

Console.Write(text1.Open());

text1.Clear();

Console.Write(text1.Open());