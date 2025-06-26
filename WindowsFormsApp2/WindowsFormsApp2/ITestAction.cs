using System;

namespace WindowsFormsApp2
{
    public interface ITestAction
    {
        // Создание теста
        void CreateTest();

        // Удаление теста
        void DeleteTest();
    }
}