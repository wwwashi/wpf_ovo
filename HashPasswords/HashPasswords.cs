using System;
using System.Security.Cryptography;

namespace HashPasswords
{
    public static class HashPasswords
    {
        public static string Hash(string password)
        {
            // Создаем объект класса SHA256CryptoServiceProvider
            var sha256 = new SHA256CryptoServiceProvider();

            // Вычисляем хеш пароля
            var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            // Возвращаем хеш в виде строки
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}
