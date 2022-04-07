using Task01._1;
using Task01._1.TrainingMaterialElements;

TrainingLesson trainingLesson1 = new TrainingLesson("Training lesson1 description");
TrainingLesson trainingLesson2 = new TrainingLesson("Training lesson2 description");

Console.WriteLine(trainingLesson1.ToString());
Console.WriteLine(trainingLesson2.ToString());

trainingLesson1.AddLessonMaterial(new TextMaterial("Text material1 for training lesson1"));
trainingLesson1.AddLessonMaterial(new TextMaterial("Text material2 for training lesson1"));
//trainingLesson1.AddLessonMaterial(new VideoMaterial("Video material1 for training lesson1"));

Console.WriteLine(trainingLesson1.TrainingType());
//trainingLesson1.uniqueIdentifier = 3;
trainingLesson1.GenerateUniqueIdentifier();
Console.WriteLine(trainingLesson1.UniqueIdentifier);

//trainingLesson2.uniqueIdentifier = 3;
trainingLesson2.GenerateUniqueIdentifier();
Console.WriteLine(trainingLesson2.UniqueIdentifier);

Console.WriteLine(trainingLesson1.Equals(trainingLesson2));

Console.WriteLine(trainingLesson1.Version);

trainingLesson1.Version = "1";
Console.WriteLine(trainingLesson1.Version);

TrainingLesson clonedLesson = (TrainingLesson)trainingLesson1.Clone();
clonedLesson.Version = "2";
Console.WriteLine(clonedLesson.Version);
clonedLesson.AddLessonMaterial(new VideoMaterial("Description for cloned lesson video material"));
clonedLesson.Description = "Description for cloned lesson";
Console.WriteLine(trainingLesson1.Description);
Console.WriteLine(clonedLesson.Description);
Console.WriteLine("checking types");

Console.WriteLine(trainingLesson1.TrainingType());
Console.WriteLine(clonedLesson.TrainingType());
Console.WriteLine(trainingLesson1.Equals(clonedLesson));
