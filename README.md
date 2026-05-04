# Лабораторна робота 1 — Windows Forms та WPF

Застосунок "Гастрономічне опитування" реалізований двома способами: за допомогою **Windows Presentation Foundation (WPF)** та **Windows Forms**.

## Структура проекту

```
lab1/
├── SurveyApp/          # WPF-версія
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   └── SurveyApp.csproj
└── SurveyWinForms/     # Windows Forms-версія
    ├── Program.cs
    ├── SurveyForm.cs
    ├── SurveyForm.Designer.cs
    └── SurveyWinForms.csproj
```

## Функціональність

- 4 питання про гастрономічні уподобання користувача
- Навігація між питаннями (кнопки "Назад" / "Далі")
- Збереження відповідей у текстовий файл на Робочому столі
- Прогрес-бар із поточним номером питання

## Питання опитування

1. Яка страва нагадує вам дитинство або рідний дім?
2. Яку кухню світу ви могли б їсти щодня?
3. Ви скоріше кухар чи гурман? Є фірмова страва?
4. Складіть ідеальне меню на один день.

## Дизайн

| Версія | Тема |
|--------|------|
| WPF | Темна "крейдяна дошка" — фон `#1C1C1E`, акцент `#FF7A2F` |
| Windows Forms | Темно-зелена "свіжі продукти" — фон `#0F2419`, акцент `#7ED957` |

## Збірка та запуск

Вимоги: **.NET Framework 4.0** (входить до складу Windows).

```powershell
# WPF
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe SurveyApp\SurveyApp.csproj /p:Configuration=Release

# Windows Forms
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe SurveyWinForms\SurveyWinForms.csproj /p:Configuration=Release
```

Виконувані файли: `SurveyApp\bin\Release\SurveyApp.exe` та `SurveyWinForms\bin\Release\SurveyWinForms.exe`

## Автор

Студент: Артем Пальчук  
Дисципліна: Програмування інтерфейсів користувача (ПІК)
