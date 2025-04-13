namespace Colections
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>()
            {
            new Student { Name = "Необычный Злой Гусь", Faculty = "Информатика", Grades = new List<int> { 5, 4, 5, 3 } },
            new Student { Name = "Добрый Внезапныйлось", Faculty = "Математика", Grades = new List<int> { 4, 4, 4, 4 } },
            new Student { Name = "Верный Денег Нет, Но Вы Держитесь!", Faculty = "Информатика", Grades = new List<int> { 5, 5, 5, 5 } },
            new Student { Name = "Душевный Потные Носки", Faculty = "Математика", Grades = new List<int> { 3, 4, 5, 4 } },
            new Student { Name = "Восхитительный Краснопяточный Грядкоторчатель", Faculty = "Физика", Grades = new List<int> { 5, 4, 5, 4 } },
            new Student { Name = "Прикольный Козалосьбыкоса", Faculty = "Информатика", Grades = new List<int> { 4, 4, 5, 4 } },
            new Student { Name = "Восходящий Какуля", Faculty = "Математика", Grades = new List<int> { 5, 5, 5, 4 } },
            new Student { Name = "Дорогой Накуренный Волшебник", Faculty = "Физика", Grades = new List<int> { 4, 3, 4, 3 } }
            };

            var studentsByFaculty = students.GroupBy(s => s.Faculty);

            foreach (var facultyGroup in studentsByFaculty)
            {
                string facultyName = facultyGroup.Key;

                double averageFacultyGrade = facultyGroup.Average(s => s.AverageGrade);

                Student bestStudent = facultyGroup.OrderByDescending(s => s.AverageGrade).First();

                Console.WriteLine($"Факультет: {facultyName}");
                Console.WriteLine($"Средний балл: {averageFacultyGrade:F2}");
                Console.WriteLine($"Лучший студент: {bestStudent.Name} (Средний балл: {bestStudent.AverageGrade:F2})\n");
            }


            
            Store<Product> productStore = new Store<Product>();

            try
            {
                productStore.Add(new Product { Id = 1, Name = "Яблоки", Price = 1.50, Category = "Продукты", Quantity = 100 });
                productStore.Add(new Product { Id = 2, Name = "Телевизор", Price = 500, Category = "Бытовая техника", Quantity = 10 });
                productStore.Add(new Product { Id = 3, Name = "Футболка", Price = 25, Category = "Одежда", Quantity = 50 });
                productStore.Add(new Product { Id = 4, Name = "Молоко", Price = 2, Category = "Продукты", Quantity = 50 });
                productStore.Add(new Product { Id = 5, Name = "Пылесос", Price = 150, Category = "Бытовая техника", Quantity = 5 });
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка добавления: {ex.Message}");
            }

            Console.WriteLine("\nСписок всех товаров:");
            productStore.ListAllProducts();

            //фильтрация товаров по категориям
            string categoryToFilter = "Продукты";
            var productsInCategory = productStore.GetProductsByCategory(categoryToFilter);
            Console.WriteLine($"\nТовары в категории '{categoryToFilter}':");
            foreach (var product in productsInCategory)
            {
                Console.WriteLine($"- {product}");
            }

            //обновление цены товара
            try
            {
                productStore.UpdatePrice(2, 520);
                Console.WriteLine("\nЦена товара с Id 2 обновлена.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка обновления цены: {ex.Message}");
            }

            //обновление количества товара
            try
            {
                productStore.UpdateQuantity(3, 45);
                Console.WriteLine("Количество товара с Id 3 обновлено.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка обновления количества: {ex.Message}");
            }

            //удаление товара
            try
            {
                productStore.Remove(4);
                Console.WriteLine("\nТовар с Id 4 удален.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка удаления: {ex.Message}");
            }

            Console.WriteLine("\nСписок товаров после изменений:");
            productStore.ListAllProducts();

            //группировка товаров по категориям
            Console.WriteLine("\nТовары, сгруппированные по категориям:");
            productStore.ListAllProducts(true);

            //получение товара по Id
            int searchId = 3;
            var foundProduct = productStore.GetProductById(searchId);
            if (foundProduct != null)
            {
                Console.WriteLine($"\nНайден товар с Id {searchId}: {foundProduct}");
            }
            else
            {
                Console.WriteLine($"\nТовар с Id {searchId} не найден.");
            }
        }
    }
}
