using Sat.Recruiment.Dao.Interfaces;
using Sat.Recruiment.Model;
using System;
using System.IO;
using System.Net;
using System.Numerics;
using System.Threading.Tasks;

namespace Sat.Recruiment.Dao
{

    public class UserDao : IUserDao, IDisposable
    {
        private string path;
        private FileStream fileStream = null;
        private StreamReader reader = null;

        public UserDao(string relativePath)
        {
            path = Directory.GetCurrentDirectory() + relativePath;
        }

        public StreamReader Reader
        {
            get
            {
                fileStream ??= new FileStream(path, FileMode.OpenOrCreate);
                return reader ??= new StreamReader(fileStream);
            }
        }

        public async Task<IUser> ReadUser()
        {   
            if (Reader.Peek() >= 0)
            {
                var line = await Reader.ReadLineAsync();
                var values = line.Split(',');
                Enum.TryParse(values[4].ToString(), out UserType ut);
                var user = new User
                {
                    Name = values[0].ToString(),
                    Email = values[1].ToString(),
                    Phone = values[2].ToString(),
                    Address = values[3].ToString(),
                    UserType = ut,
                    Money = decimal.Parse(values[5].ToString()),
                };

                return user;
            }
            
            return null;
        }

        public void CloseFile()
        {
            reader?.Close();
            fileStream?.Close();
            fileStream = null;
        }

        public async Task AddUser(IUser newUser)
        {
            var line = $"{newUser.Name},{newUser.Email},{newUser.Phone},{newUser.Address},{newUser.UserType},{newUser.Money}";
            CloseFile();
            fileStream = new FileStream(path, FileMode.Append);
            using(var sw = new StreamWriter(fileStream))
            {
                await sw.WriteLineAsync(line);
            }
            CloseFile();
        }

        public void Dispose()
        {
            CloseFile();
        }
    }
}
