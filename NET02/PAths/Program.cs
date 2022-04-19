using System.Reflection;

var assembly = Assembly.LoadFrom("C:\\Users\\VitaGriciute\\source\\repos\\TrainingCetnerTasks\\NET02\\WordListener\\bin\\Debug\\net6.0\\WordListener.dll");
//Console.WriteLine();
var types = assembly.GetTypes();

Console.WriteLine(assembly.FullName);
