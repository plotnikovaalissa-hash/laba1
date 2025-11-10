using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVideoEquipment
{
    // Базовый класс для аудио-видео техники
    public class AudioVideoAppliance
    {
        private string brand;
        private double price;

        // Свойство для установки и получения бренда
        public string Brand
        {
            get { return brand; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Ошибка: Бренд не может быть пустым");
                    return;
                }
                if (value.Length > 50)
                {
                    Console.WriteLine("Ошибка: Бренд не может превышать 50 символов");
                    return;
                }
                brand = value.Trim();
            }
        }

        // Свойство для установки и получения цены
        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Ошибка: Цена должна быть больше 0");
                    return;
                }
                if (value > 1000000)
                {
                    Console.WriteLine("Ошибка: Цена не должна превышать 1,000,000");
                    return;
                }
                price = Math.Round(value, 2);
            }
        }

        // Конструктор по умолчанию
        public AudioVideoAppliance()
        {
            brand = "Unknown";
            price = 300.0;
        }

        // Метод для вывода информации об оборудовании
        public virtual void Print()
        {
            Console.WriteLine($"\nБренд: {Brand}\nЦена: ${Price:F2}");
        }
    }

    // Класс для телевизора, наследующий от AudioVideoAppliance
    public class Televizor : AudioVideoAppliance
    {
        private int model;
        private int diagonal;
        private bool smartControl;

        // Свойство для установки и получения модели
        public int Model
        {
            get { return model; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Ошибка: Модель должна быть между 0 и 100");
                    return;
                }
                model = value;
            }
        }

        // Свойство для установки и получения диагонали
        public int Diagonal
        {
            get { return diagonal; }
            set
            {
                if (value < 32 || value > 85)
                {
                    Console.WriteLine("Ошибка: Диагональ должна быть между 32 и 85");
                    return;
                }
                diagonal = value;
            }
        }

        // Свойство для установки и получения умного контроля
        public bool SmartControl
        {
            get { return smartControl; }
            set { smartControl = value; }
        }

        // Конструктор по умолчанию
        public Televizor() : base()
        {
            model = 7;
            diagonal = 40;
            smartControl = false;
        }

        // Переопределение метода Print для вывода информации о телевизоре
        public override void Print()
        {
            Console.WriteLine("\n=== Телевизор ===");
            base.Print();
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Диагональ: {Diagonal} см");
            Console.WriteLine($"Умный контроль: {(SmartControl ? "Да" : "Нет")}");
        }
    }

    // Класс для радио, наследующий от AudioVideoAppliance
    public class Radio : AudioVideoAppliance
    {
        private string model;
        private int stations;
        private int volna;
        private bool hasDisplay;


        // Свойство для установки и получения модели радио
        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Ошибка: Модель не может быть пустой");
                    return;
                }
                if (value.Length > 30)
                {
                    Console.WriteLine("Ошибка: Модель не может превышать 30 символов");
                    return;
                }
                model = value.Trim();
            }
        }

        // Свойство для установки и получения количества станций
        public int Stations
        {
            get { return stations; }
            set
            {
                if (value < 4 || value > 10)
                {
                    Console.WriteLine("Ошибка: Количество станций должно быть между 4 и 10");
                    return;
                }
                stations = value;
            }
        }

        // Свойство для установки и получения длины волны
        public int Volna
        {
            get { return volna; }
            set
            {
                if (value < 80 || value > 150)
                {
                    Console.WriteLine("Ошибка: Длина волны должна быть между 80 и 150");
                    return;
                }
                volna = value;
            }
        }

        // Свойство для установки и получения наличия дисплея
        public bool HasDisplay
        {
            get { return hasDisplay; }
            set { hasDisplay = value; }
        }

        // Конструктор по умолчанию
        public Radio() : base()
        {
            model = "Standard";
            stations = 8;
            volna = 100;
            hasDisplay = false;
        }

        // Переопределение метода Print для вывода информации о радио
        public override void Print()
        {
            Console.WriteLine("\n=== Радио ===");
            base.Print();
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Количество станций: {Stations}");
            Console.WriteLine($"Длина волны: {Volna} м");
            Console.WriteLine($"Дисплей: {(HasDisplay ? "Есть" : "Нет")}");
        }
    }

    // Основной класс программы
    public class Program
    {
        static void Main()
        {
            List<AudioVideoAppliance> devices = new List<AudioVideoAppliance>();
            char choice;

            while (true)
            {
                ShowMenu();
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == '4')
                {
                    break;
                }

                ProcessUserChoice(choice, devices);
            }

            Console.WriteLine("Спасибо за использование программы!");
        }

        // Метод для отображения меню
        public static void ShowMenu()
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("Система управления А/В техникой");
            Console.WriteLine("=================================");
            Console.WriteLine("1 - Просмотреть все устройства");
            Console.WriteLine("2 - Добавить телевизор");
            Console.WriteLine("3 - Добавить радио");
            Console.WriteLine("4 - Выход");
            Console.Write("Выберите действие: ");
        }


        // Метод для обработки выбора пользователя
        public static void ProcessUserChoice(char choice, List<AudioVideoAppliance> devices)
        {
            switch (choice)
            {
                case '1':
                    PrintDevices(devices);
                    break;
                case '2':
                    AddTelevizor(devices);
                    break;
                case '3':
                    AddRadio(devices);
                    break;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }
        }

        // Метод для добавления нового телевизора
        public static void AddTelevizor(List<AudioVideoAppliance> devices)
        {
            Console.WriteLine("\n--- Добавление телевизора ---");

            var televizor = new Televizor();

            // Ввод бренда с проверкой
            while (true)
            {
                Console.Write("Введите бренд: ");
                string inputBrand = Console.ReadLine();
                televizor.Brand = inputBrand;
                if (!string.IsNullOrEmpty(televizor.Brand))
                    break;
            }

            // Ввод цены с проверкой
            while (true)
            {
                Console.Write("Введите цену ($): ");
                if (double.TryParse(Console.ReadLine(), out double price))
                {
                    televizor.Price = price;
                    if (televizor.Price > 0)
                        break;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное число");
                }
            }

            // Ввод модели с проверкой
            while (true)
            {
                Console.Write("Введите модель (0-100): ");
                if (int.TryParse(Console.ReadLine(), out int model))
                {
                    televizor.Model = model;
                    if (televizor.Model >= 0 && televizor.Model <= 100)
                        break;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное число");
                }
            }

            // Ввод диагонали с проверкой
            while (true)
            {
                Console.Write("Введите диагональ (32-85): ");
                if (int.TryParse(Console.ReadLine(), out int diagonal))
                {
                    televizor.Diagonal = diagonal;
                    if (televizor.Diagonal >= 32 && televizor.Diagonal <= 85)
                        break;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное число");
                }
            }

            // Ввод умного контроля
            while (true)
            {
                Console.Write("Умный контроль? (1 - Да, 0 - Нет): ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    televizor.SmartControl = true;
                    break;
                }
                else if (input == "0")
                {
                    televizor.SmartControl = false;
                    break;
                }
                Console.WriteLine("Ошибка: Введите 1 или 0");
            }

            devices.Add(televizor);
            Console.WriteLine("Телевизор успешно добавлен!");
        }

        // Метод для добавления нового радио
        public static void AddRadio(List<AudioVideoAppliance> devices)
        {
            Console.WriteLine("\n--- Добавление радио ---");

            var radio = new Radio();

            // Ввод бренда с проверкой
            while (true)
            {
                Console.Write("Введите бренд: ");
                string inputBrand = Console.ReadLine();
                radio.Brand = inputBrand;
                if (!string.IsNullOrEmpty(radio.Brand))
                    break;
            }


            // Ввод цены с проверкой
            while (true)
            {
                Console.Write("Введите цену ($): ");
                if (double.TryParse(Console.ReadLine(), out double price))
                {
                    radio.Price = price;
                    if (radio.Price > 0)
                        break;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное число");
                }
            }

            // Ввод модели радио с проверкой
            while (true)
            {
                Console.Write("Введите модель радио: ");
                string inputModel = Console.ReadLine();
                radio.Model = inputModel;
                if (!string.IsNullOrEmpty(radio.Model))
                    break;
            }

            // Ввод количества станций с проверкой
            while (true)
            {
                Console.Write("Введите количество станций (4-10): ");
                if (int.TryParse(Console.ReadLine(), out int stations))
                {
                    radio.Stations = stations;
                    if (radio.Stations >= 4 && radio.Stations <= 10)
                        break;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное число");
                }
            }

            // Ввод длины волны с проверкой
            while (true)
            {
                Console.Write("Введите длину волны (80-150): ");
                if (int.TryParse(Console.ReadLine(), out int volna))
                {
                    radio.Volna = volna;
                    if (radio.Volna >= 80 && radio.Volna <= 150)
                        break;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное число");
                }
            }

            // Ввод наличия дисплея
            while (true)
            {
                Console.Write("Есть дисплей? (1 - Да, 0 - Нет): ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    radio.HasDisplay = true;
                    break;
                }
                else if (input == "0")
                {
                    radio.HasDisplay = false;
                    break;
                }
                Console.WriteLine("Ошибка: Введите 1 или 0");
            }

            devices.Add(radio);
            Console.WriteLine("Радио успешно добавлено!");
        }

        // Метод для вывода информации о всех устройствах
        public static void PrintDevices(List<AudioVideoAppliance> devices)
        {
            if (devices.Count == 0)
            {
                Console.WriteLine("\nУстройств нет в списке.");
                return;
            }

            Console.WriteLine($"\n=== Список устройств (всего: {devices.Count}) ===");
            for (int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine($"\n--- Устройство #{i + 1} ---");
                devices[i].Print();
            }
        }
    }
}
