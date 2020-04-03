using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Life_Game
{
    public partial class Form1 : Form {
        private int eaten = 0;
        private int Male = 0;
        private int Female = 0;
        private long time = 0; // кол-во шагов (время от рождения первых клеток)
        private Graphics graphics;
        private List<Meal> meals = new List<Meal>(); // список еды
        private List<Cell> population = new List<Cell>() { // список клеток
            // первые клетки
            new Cell(Sex.Male, new Point(683, 384)),
            new Cell(Sex.Female, new Point(683, 384))
        };

        public Form1() {
            InitializeComponent();
            graphics = pictureBox.CreateGraphics();
            timer.Enabled = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            pictureBox.Refresh();
            foreach (var cell in population)
            {
                cell.Run();
                if (IsMeal(cell)) cell.HaveLunch();
                graphics.FillEllipse(cell.Color, cell.Location.X, cell.Location.Y, Cell.Radius, Cell.Radius);

            }
            foreach (var meal in meals)
                graphics.FillEllipse(meal.Color, meal.Location.X, meal.Location.Y, Meal.Radius, Meal.Radius);
            if (population.Count > 500)
            {
                timer.Stop();
                MessageBox.Show(" Еды съедено " + eaten + "\n Мужчин " + Male + "\n Женщин " + Female + "\n Время работы пограммы " + time);

                foreach (var cell in population)
                {
                    cell.Kill();
                    pictureBox.Refresh();
                }
            }
            population.RemoveAll(IsNotAlive); // убиваем всех старичков

            NewCell();  // рожаем новые клетки
            NewMeal();
        }

        // make out - появление новой клетки
        private bool IsMakeOut(Cell male, Cell female) {
            var sexRadius = 20;
            return (   Math.Abs(male.Location.X - female.Location.X) <= sexRadius // если клетки находятся друг от друга в радиусе n пикселей,
                    && Math.Abs(male.Location.Y - female.Location.Y) <= sexRadius // то они могут сделать потомка
                    && male.Sex != female.Sex);
        }
        // проверка на еду
        private bool IsMeal(Cell cell) // 
        {
            var mealRadius = 10;
            var eated = -1; // индекс съеденной еды
            var isEated = false; // было ли что-то съедено?
            for(var i = 0; i < meals.Count; i++)
                if (Math.Abs(meals[i].Location.X - cell.Location.X) <= mealRadius && Math.Abs(meals[i].Location.Y - cell.Location.Y) <= mealRadius){
                    isEated = true;
                    eated = i;
                    ++eaten;
                    break;
                }

            if (eated != -1) meals.RemoveAt(eated);
            return isEated;
        }

        private bool IsNotAlive(Cell cell)
        {
            return cell.Age == 0;
        }

        private void NewCell() {
            var kids = new List<Cell>(); // здесь будут потомки, появшиеся от пересечения 
            var randSex = new Random();
            var randLocation = new Random();
            // ищем любовничков
            for (var firstParent = 0; firstParent < population.Count; firstParent++) {
                for (var secondParent = firstParent + 1; secondParent < population.Count; secondParent++) {
                    if (IsMakeOut(population[firstParent], population[secondParent])) {
                        // новый гендерный пол
                        var newSex = (Sex)randSex.Next(0, 2);
                        switch (newSex) {
                            case (Sex.Male):
                                ++Male;
                                break;
                            case (Sex.Female):
                                ++Female;
                                break;
                        }

                        // новая локация, так как делать клетку на месте рождения - самоубийство
                        // они начинают плодиться в геометрической прогрессии. Разом.
                        // пускай рождаются в радиусе 100 пикселей
                        var bornRadius = 50;
                        var bornX = population[secondParent].Location.X + randLocation.Next(-bornRadius, bornRadius);
                        var bornY = population[secondParent].Location.Y + randLocation.Next(-bornRadius, bornRadius);
                        var newLocation = new Point(bornX, bornY);

                        // здоровье ребёнка зависит от здоровья родителей
                        int newAge;
                        if (population[firstParent].Age >= 20 || population[secondParent].Age >= 20)
                            newAge = 40;
                        else
                            newAge = 20;

                        kids.Add(new Cell(newSex, newLocation, newAge));
                    }
                }
            }

            foreach (var kid in kids)
                population.Add(kid);
        }

        private void NewMeal()
        {
            var timeAppereance = 5;
            if (time % timeAppereance == 0) meals.Add(new Meal());
        }
    }
}
