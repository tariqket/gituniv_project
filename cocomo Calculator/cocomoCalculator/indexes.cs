using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocomoCalculator
{
    static class indexes
    {
        private static Dictionary<string, double[,]> softwareType = new Dictionary<string, double[,]>();
        private static Dictionary<string, double[]> costDrivers = new Dictionary<string, double[]>();

        public static void fillData()
        {
            fillSftwareType();
            fillCostDrivers();
        }

        public static string [] getProjectTypes()
        {
            string[] projectTypes = new string[softwareType.Count];
            int i = 0;
            foreach (KeyValuePair<string, double[,]> kvp in softwareType)
            {
                projectTypes[i] = kvp.Key;
                i++;
            }


            return projectTypes;
        }

        public static double[] getIndexesByPrjName(string projName, int basInter)
        {
            // 0 basic
            // 1 intermediate
            double[,] indexes = softwareType[projName];

            if (basInter == 0)
            {
                return new double []{ indexes[0,0],indexes[0, 1],indexes[0, 2],indexes[0, 3]};
            }
            else
            {
                return new double[] { indexes[1, 0], indexes[1, 1], indexes[1, 2], indexes[1, 3] };
            }
        }





        private static void fillSftwareType()
        {
            // "type name" [[indexes for basic],[indexes for intermediate]]
            // basic {a,b,c,d} 
            // intermediate {a,b. null. null}
            softwareType.Add("Распространенный", 
                new[,] { { 2.4, 1.05, 2.5, 0.38 }, { 3.2, 1.05, 0, 0 } }
                );
            softwareType.Add("Полунезависимый",
                new[,] { { 3.0, 1.12, 2.5, 0.35 }, { 3.0, 1.12, 0, 0 } }
                );
            softwareType.Add("Встроенный",
                new[,] { { 3.6, 1.20, 2.5, 0.32 }, { 2.8, 1.20, 0, 0 } }
                );
        }
        private static void fillCostDrivers()
        {
            // "name" -> [ratings]
            // ratings [veryLow,Low,Normal,Hight,VeryHight,ExtraHight]
            // when attribute is null use -1

            // if normal return 1
            

            //-----------Product
            costDrivers.Add("Требуемая надежность ПО", 
                new[] {0.75, 0.88, 1.0, 1.15, 1.40, -1}
                );
            costDrivers.Add("Размер БД приложения",
                new[] { -1, 0.94, 1.0, 1.08, 1.16, -1 }
                );
            costDrivers.Add("Сложность продукта",
                new[] { 0.7, 0.85, 1.0, 1.15, 1.3, 1.65 }
                );
            //----------Hardware
            costDrivers.Add("Ограничения быстродействия при выполнении программы",
                new[] { -1, -1, 1, 1.11, 1.3, 1.66 }
                );
            costDrivers.Add("Ограничения памяти",
                new[] { -1, -1, 1, 1.06, 1.21, 1.56 }
                );
            costDrivers.Add("Неустойчивость окружения виртуальной машины",
                new[] { -1, 0.87, 1, 1.15, 1.30, -1 }
                );
            costDrivers.Add("Требуемое время восстановления",
                new[] { -1, 0.87, 1, 1.07, 1.15, -1 }
                );
            //---------Personnal
            costDrivers.Add("Аналитические способности",
                new[] { 1.46, 1.19, 1, 0.86, 0.75, -1 }
                );
            costDrivers.Add("Опыт разработки",
                new[] { 1.29, 1.13, 1, 0.91, 0.82, -1 }
                );
            costDrivers.Add("Способности к разработке ПО",
                new[] { 1.42, 1.17, 1, 0.86, 0.7, -1 }
                );
            costDrivers.Add("Опыт использования виртуальных машин",
                new[] { 1.21, 1.10, 1.0, 0.9, -1, -1 }
                );
            costDrivers.Add("Опыт разработки на языках программирования",
            new[] { 1.14, 1.07, 1.0, 0.95, -1, -1 }
            );
            //-----------Project
            costDrivers.Add("Применение методов разработки ПО",
                new[] { 1.24, 1.10, 1.0, 0.91, 0.82, -1 }
                );
            costDrivers.Add("Использование инструментария разработки ПО",
                new[] { 1.24, 1.10, 1.0, 0.91, 0.83, -1 }
                );
            costDrivers.Add("Требования соблюдения графика разработки",
                new[] { 1.24, 1.10, 1.0, 0.91, 0.83, -1 }
                );
        }
    }
}
