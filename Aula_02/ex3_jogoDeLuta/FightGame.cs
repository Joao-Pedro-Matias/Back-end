    class Character
    {
        // Atributos

        public string Name { get; private set; }

        public int Life { get; private set; }

        public int PowerAttack { get; private set; }

        public int PowerDefense { get; private set; }

        public bool IsAlive { get; private set; }

        //Construtores

        public Character(string name)
        {
            Name = name;
            Life = 100;
            PowerAttack = PowerGenerate(20, 31);
            PowerDefense = PowerGenerate(10, 16);
            IsAlive = true;

        }

        //Métodos

        public void Attack(Character opponet)
        {
            if (!IsAlive)
                throw new Exception("Operação invalida, personame está morto");
            opponet.Damage(this.PowerAttack - opponet.PowerDefense);
        }

        private void Damage(int value)
        {
            Life -= value;

            if (Life <= 0)
                IsAlive = false;

        }

        private int PowerGenerate(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }



        //ToString

        public override string ToString()
        {
            return $"Nome: {Name}\tVida = {Life}";
        }
    }