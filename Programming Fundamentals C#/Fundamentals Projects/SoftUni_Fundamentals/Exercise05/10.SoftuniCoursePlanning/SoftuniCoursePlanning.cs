using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftuniCoursePlanning
{
    class SoftuniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            List<string> commands = Console.ReadLine().Split(':').ToList();
            string end = "course start";
            string command = commands[0];
            string lesson = "";
            string exercise = "";

            while (command != end)
            {
                lesson = commands[1];
                exercise = $"{lesson}-Exercise";


                if (command == "Add")
                {
                    if (!lessons.Contains(lesson))
                    {
                        Add(lessons, lesson);
                    }
                }

                else if (command == "Insert")
                {
                    int index = int.Parse(commands[2]);

                    if (!lessons.Contains(lesson))
                    {
                        Insert(lessons, lesson, index);
                    }
                }

                else if (command == "Remove")
                {
                    exercise = $"{lesson}-Exercise";
                    if (lessons.Contains(lesson))
                    {
                        Remove(lessons, lesson);

                        if (lessons.Contains(exercise))
                        {
                            RemoveExercise(lessons, exercise);
                        }
                    }
                }

                else if (command == "Swap")
                {
                    string lesson1 = commands[1];
                    string lesson2 = commands[2];
                    string exercise1 = $"{lesson1}-Exercise";
                    string exercise2 = $"{lesson2}-Exercise";

                    if (lessons.Contains(lesson1) && lessons.Contains(lesson2))
                    {
                        Swap(lessons, lesson1, lesson2);
                    }

                    if (lessons.Contains(exercise1) && lessons.Contains(exercise2))
                    {
                        Swap(lessons, exercise1, exercise2);
                    }

                    else if (lessons.Contains(exercise1) || lessons.Contains(exercise2))
                    {
                        SwapExercise(lessons, exercise1, exercise2, lesson2, lesson1);
                    }
                }

                else if (command == "Exercise")
                {
                    exercise = $"{lesson}-Exercise";
                    if (!lessons.Contains(lesson))
                    {
                        Add(lessons, lesson);
                    }

                    Exercise(lessons, lesson, exercise);
                }

                commands = Console.ReadLine().Split(':').ToList();
                command = commands[0];
            }
            Print(lessons);
        }

        static List<string> Add(List<string> lessons, string lesson)
        {
            lessons.Add(lesson);
            return lessons;
        }

        static List<string> Insert(List<string> lessons, string lesson, int index)
        {
            lessons.Insert(index, lesson);
            return lessons;
        }

        static List<string> Remove(List<string> lessons, string lesson)
        {
            lessons.Remove(lesson);
            return lessons;
        }

        static List<string> Swap(List<string> lessons, string lesson1, string lesson2)
        {
            int lesson1Index = 0;
            int lesson2Index = 0;

            for (int index = 0; index < lessons.Count; index++)
            {
                if (lessons[index] == lesson1)
                {
                    lesson1Index = index;
                }

                else if (lessons[index] == lesson2)
                {
                    lesson2Index = index;
                }
            }

            lessons[lesson1Index] = lesson2;
            lessons[lesson2Index] = lesson1;
            return lessons;
        }

        static List<string> Exercise(List<string> lessons, string lesson, string exercise)
        {
            int lessonIndex = 0;
            for (int index = 0; index < lessons.Count; index++)
            {
                if (lessons[index] == lesson)
                {
                    lessonIndex = index;
                    break;
                }
            }

            int exerciseIndex = lessonIndex + 1;

            if (!lessons.Contains(exercise))
            {
                lessons.Insert(exerciseIndex, $"{lesson}-Exercise");
            }

            return lessons;
        }

        static List<string> SwapExercise(List<string> lessons, string exercise1, string exercise2, string lesson1, string lesson2)
        {
            
            int exercise1Index = 0;
            int exercise2Index = 0;

            for (int index = 0; index < lessons.Count; index++)
            {

                if (lessons[index] == exercise1)
                {
                    exercise1Index = index;
                }

                else if (lessons[index] == exercise2)
                {
                    exercise2Index = index;
                }
            }

            Remove(lessons, exercise1);
            Remove(lessons, exercise2);

            int lesson1Index = 0;
            int lesson2Index = 0;

            for (int index = 0; index < lessons.Count; index++)
            {
                if (lessons[index] == lesson1)
                {
                    lesson1Index = index;
                }

                else if (lessons[index] == lesson2)
                {
                    lesson2Index = index;
                }
            }

            if (exercise1Index == 0 && exercise2Index != 0)
            {
                Insert(lessons, exercise2, lesson1Index + 1);
            }

            else if (exercise1Index != 0 && exercise2Index == 0)
            {
                Insert(lessons, exercise1, lesson2Index + 1);
            }

            return lessons;
        }

        static List<string> RemoveExercise(List<string> lessons, string exercise)
        {
            lessons.Remove(exercise);
            return lessons;
        }

        static void Print(List<string> lessons)
        {
            int count = 1;
            for (int index = 0; index < lessons.Count; index++)
            {
                string lessonTitle = lessons[index];

                Console.WriteLine($"{count}.{lessonTitle}");
                count++;
            }
        }
    }
}
