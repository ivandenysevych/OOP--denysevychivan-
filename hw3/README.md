# Доповідь: Принципи ISP та DIP
Доповідь: Принципи ISP та DIP у розробці ПЗ
1. Принцип розділення інтерфейсу (ISP)
Interface Segregation Principle (ISP) стверджує: клієнти не повинні залежати від методів, які вони не використовують. Замість одного великого інтерфейсу краще створити кілька спеціалізованих.

Приклад порушення ISP
Уявімо інтерфейс для багатофункціонального пристрою:

C#
public interface IMachine
{
    void Print();
    void Scan();
    void Fax();
}

// Проста друкарка змушена реалізовувати методи, які їй не потрібні
public class SimplePrinter : IMachine
{
    public void Print() => Console.WriteLine("Printing...");
    public void Scan() => throw new NotImplementedException(); // Порушення!
    public void Fax() => throw new NotImplementedException();  // Порушення!
}
Вирішення проблеми (ISP Applied)
Розділяємо інтерфейс на "вузькі" сегменти:

C#
public interface IPrinter { void Print(); }
public interface IScanner { void Scan(); }
public interface IFax    { void Fax(); }

public class SimplePrinter : IPrinter
{
    public void Print() => Console.WriteLine("Printing...");
}

public class MultiFunctionDevice : IPrinter, IScanner
{
    public void Print() => Console.WriteLine("Printing...");
    public void Scan() => Console.WriteLine("Scanning...");
}
2. Принцип інверсії залежностей (DIP) та Dependency Injection
Dependency Inversion Principle (DIP) каже: модулі верхнього рівня не повинні залежати від модулів нижнього рівня. Обидва мають залежати від абстракцій.

Переваги застосування DIP через Dependency Injection (DI):
Гнучкість: Ми можемо змінити реалізацію (наприклад, замінити базу даних SQL на MongoDB), не змінюючи код бізнес-логіки.

Слабкий зв'язок (Loose Coupling): Класи не створюють свої залежності самі через new, а отримують їх ззовні.

Легкість підтримки: Код стає чистішим, оскільки кожен клас займається своєю справою, а не налаштуванням оточення.

3. Зв'язок ISP, DI та тестування
"Вузькі" інтерфейси (ISP) значно полегшують життя при використанні DI та написанні тестів:

Кращий DI: Коли ми просимо контейнер надати залежність, він надає рівно те, що потрібно. Клас не отримує зайвого функціоналу "вагоном".

Простіше тестування (Mocking): При написанні Unit-тестів набагато легше створити "заглушку" (Mock) для інтерфейсу з одним методом, ніж для гігантського інтерфейсу з 20 методами, більшість з яких не впливають на тест.

Чистота тестів: Тести стають більш сфокусованими, оскільки вони перевіряють лише ту взаємодію, яка дійсно потрібна для конкретного сценарію.
