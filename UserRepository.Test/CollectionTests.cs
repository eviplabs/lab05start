namespace UserRepository.Test
{
    public class CollectionTests
    {
        static List<int> GenerateNumbers(int count)
        {
            int[] numbers = Enumerable.Range(0, 2000).ToArray();
            Random rand = new Random();
            for (int i = numbers.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
            return numbers.Take(count).ToList();
        }
        static List<User> GenerateUsers(int count)
        {
            var users = new List<User>();
            var numbers = GenerateNumbers(count);
            foreach (var id in numbers)
            {
                users.Add(new User("Teszt", "User", id % 70, $"id_{id}"));
            }
            return users;
        }

        [Fact]
        public void ArrayInsertTest()
        {
            var repository = new ArrayUserRepository();
            var users = GenerateUsers(10);
            foreach (var user in users)
            {
                repository.Insert(user);
            }
            Assert.Equal(users.Count, repository.Count());
            Assert.Equal(users[8], repository.Get(8));
            Assert.Equal(users[5], repository.GetById(users[5].Id));
        }

        [Fact]
        public void ListInsertTest()
        {
            var repository = new ListUserRepository();
            var users = GenerateUsers(20);
            foreach (var user in users)
            {
                repository.Insert(user);
            }
            Assert.Equal(users.Count, repository.Count());
            Assert.Equal(users[8], repository.Get(8));
            Assert.Equal(users[5], repository.GetById(users[5].Id));
        }

        [Fact]
        public void OrderedListInsertTest()
        {
            var repository = new OrderedListUserRepository();
            var users = GenerateUsers(20);
            foreach (var user in users)
            {
                repository.Insert(user);
            }
            Assert.Equal(users.Count, repository.Count());
            Assert.Equal(users.OrderBy(u => u.Id).ElementAt(8), repository.Get(8));
            Assert.Equal(users.OrderBy(u => u.Id).ElementAt(12), repository.Get(12));
            Assert.Equal(users.OrderBy(u => u.Id).ElementAt(17), repository.Get(17));
            Assert.Equal(users[5], repository.GetById(users[5].Id));
        }

        [Fact]
        public void LinkedListInsertTest()
        {
            var repository = new LinkedListUserRepository();
            var users = GenerateUsers(20);
            foreach (var user in users)
            {
                repository.Insert(user);
            }
            Assert.Equal(users.Count, repository.Count());
            Assert.Equal(users.OrderBy(u => u.Id).ElementAt(8), repository.Get(8));
            Assert.Equal(users.OrderBy(u => u.Id).ElementAt(12), repository.Get(12));
            Assert.Equal(users.OrderBy(u => u.Id).ElementAt(17), repository.Get(17));
            Assert.Equal(users[5], repository.GetById(users[5].Id));
        }

        [Fact]
        public void DictionaryInsertTest()
        {
            var repository = new LinkedListUserRepository();
            var users = GenerateUsers(20);
            foreach (var user in users)
            {
                repository.Insert(user);
            }
            Assert.Equal(users.Count, repository.Count());
            Assert.Equal(users[5], repository.GetById(users[5].Id));
            Assert.Equal(users[12], repository.GetById(users[12].Id));
            Assert.Equal(users[17], repository.GetById(users[17].Id));
        }
    }
}