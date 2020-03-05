using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Battleship
{
    public partial class MainWindow : Window
    {
        public static int SIZE = 10;
        public static string MESSAGE_1 = "Открыть поле";
        public static string MESSAGE_2 = "Скрыть поле";
        private Random random = new Random();
        Button[,] playerButtons, enemyButtons;
        int buttonSize = 25;
        bool isForPlayer = true;
        bool fieldFilled = false;
        bool isMouseInput = false;
        bool isRandomInput = false;
        int enemyHits = 0;
        int playerHits = 0;
        SolidColorBrush hittenColor = Brushes.DarkRed;

        SolidColorBrush playerShipsColor = Brushes.Coral;
        SolidColorBrush playerSeaColor = Brushes.LightBlue;

        SolidColorBrush enemyShipsColor = Brushes.SaddleBrown;
        SolidColorBrush enemySeaColor = Brushes.SteelBlue;

        int playerChosenButtonsCount = 0;
        int randomI, randomJ, occupation;
        bool isShipSet = false;
        bool canSet = true;
        public MainWindow()
        {
            InitializeComponent();
            playerButtons = CreateButtons(playerButtons, true);
            AddToPanel(playerButtons, playerField);
            enemyButtons = CreateButtons(enemyButtons, false);
            AddToPanel(enemyButtons, enemyField);
            startButton.IsEnabled = false;
        }

        private void PlayerOnClick(object sender, EventArgs eventArgs)
        {
            if ((!fieldFilled)&&(isMouseInput))
            {
                Button button = (Button)sender;
                if (button.Background != playerShipsColor)
                {
                    button.Background = playerShipsColor;
                    button.Tag = 1;
                    playerChosenButtonsCount++;
                }
                else if (button.Background == playerShipsColor)
                {
                    button.Background = playerSeaColor;
                    button.Tag = 0;
                    playerChosenButtonsCount--;
                }
                if (playerChosenButtonsCount == 20)
                    startButton.IsEnabled = true;
                else
                    startButton.IsEnabled = false;
            }
        }

        private void AddToPanel(Button[,] buttons, WrapPanel panel)
        {
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    panel.Children.Add(buttons[i, j]);
        }

        private Button[,] CreateButtons(Button[,] buttons, bool isForPlayer)
        {
            SolidColorBrush brush;
            if (isForPlayer)
            {
                brush = playerSeaColor;
            }
            else {
                brush = enemySeaColor;
            }
            buttons = new Button[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = buttonSize;
                    buttons[i, j].Height = buttonSize;
                    buttons[i, j].Content = null;
                    buttons[i, j].Name = "button" + i + j;
                    buttons[i, j].Background = brush;
                    buttons[i, j].BorderBrush = Brushes.Transparent;
                    buttons[i, j].Tag = 0;  //Пусто
                    if (isForPlayer)
                    {
                        buttons[i, j].IsEnabled = true;
                        buttons[i, j].Click += PlayerOnClick;
                    }
                    else
                    {
                        buttons[i, j].IsEnabled = true;
                        buttons[i, j].Click += enemyOnClick;
                    }
                }
            }
            return buttons;
        }

        private void mouseInputButton_Click(object sender, RoutedEventArgs e)
        {
            isMouseInput = true;
            isRandomInput = false;
            mouseInputButton.IsEnabled = false;
            randomInputButton.IsEnabled = true;
            clearWaterSpace(playerButtons, true);
        }

        private void randomInputButton_Click(object sender, RoutedEventArgs e)
        {
            isRandomInput = true;
            isMouseInput = false;
            mouseInputButton.IsEnabled = true;
            randomInputButton.IsEnabled = false;
            playerChosenButtonsCount = 0;
            playerHits = 0;
            enemyHits = 0;
            clearWaterSpace(playerButtons, true);
            fillFieldWithShips(playerButtons, playerShipsColor);
            startButton.IsEnabled = true;
        }

        private void clearWaterSpace(Button[,] buttons, bool isPlayer) {
            SolidColorBrush brush;
            if (isPlayer)
            {
                brush = playerSeaColor;
            }
            else {
                brush = enemySeaColor;
            }
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    buttons[i, j].Background = brush;
                    buttons[i, j].Tag = 0;  
                    buttons[i, j].Content = "";
                }
            }
        }

        private void clearPlayerFieldButton_Click(object sender, RoutedEventArgs e)
        {
            clearWaterSpace(playerButtons, true);
            playerChosenButtonsCount = 0;
            mouseInputButton.IsEnabled = true;
            randomInputButton.IsEnabled = true;
            startButton.IsEnabled = false;
        }

        private void fillFieldWithShips(Button[,] buttons, SolidColorBrush brush)
        {
            isShipSet = false;
            //1 четырехпалубный
            SetFirstShip(4, buttons, brush);
            //Установка двух трехпалубных
            SetShip(2, 3, buttons, brush);
            //Установка трех двухпалубных
            SetShip(3, 2, buttons, brush);
            //Установка четырех однопалубных
            SetShip(4, 1, buttons, brush);
        }

        private void horizontalOccupation(int i, Button[,] buttons)
        {
            for (int m = randomI - 1; m < randomI + 2; m++)
            {
                for (int k = randomJ + i - 1; k < randomJ + i + 2; k++)
                {
                    try
                    {
                        if ((int)buttons[m, k].Tag != 1)
                        {
                            buttons[m, k].Tag = 3;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private void verticalOccupation(int i, Button[,] buttons)
        {
            for (int m = randomI + i - 1; m < randomI + i + 2; m++)
            {
                for (int k = randomJ - 1; k < randomJ + 2; k++)
                {
                    try
                    {
                        if ((int)buttons[m, k].Tag != 1)
                        {
                            buttons[m, k].Tag = 3;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private void SetFirstShip(int shipLength, Button[,] buttons,
            SolidColorBrush brush) {
                randomI = random.Next(0, SIZE - shipLength + 1);
                randomJ = random.Next(0, SIZE - shipLength + 1);
                occupation = random.Next(0, 2);
                if (occupation == 0)
                {
                    for (int i = 0; i < shipLength; i++)
                    {
                        buttons[randomI, randomJ + i].Tag = 1;
                        buttons[randomI, randomJ + i].Background = brush;
                        //Установка тегов занятости
                        horizontalOccupation(i, buttons);
                    }
                }
                else if (occupation == 1)
                {
                    for (int i = 0; i < shipLength; i++)
                    {
                        //Установка тега корабля
                        buttons[randomI + i, randomJ].Tag = 1;
                        buttons[randomI + i, randomJ].Background = brush;
                        //Установка тегов занятости
                        verticalOccupation(i, buttons);
                    }
                }
        }

        private void SetShip(int shipsCount, int shipLength, Button[,] buttons, 
            SolidColorBrush brush)
        {
            //Установка двух трехпалубных, трех двухпалубных и четырех однопалубных
            for (int k = 0; k < shipsCount; k++)
            {
                //Проверка, что рядом нет корабля или занятости
                isShipSet = false;
                while (!isShipSet)
                {
                    randomI = random.Next(0, SIZE - shipLength + 1);
                    randomJ = random.Next(0, SIZE - shipLength + 1);
                    occupation = random.Next(0, 2);

                    if (occupation == 0)
                    {
                        canSet = true;
                        for (int i = 0; i < shipLength; i++)
                            if (((int)buttons[randomI, randomJ + i].Tag == 1) ||
                                ((int)buttons[randomI, randomJ + i].Tag == 3))
                                canSet = false;
                        if (canSet)
                        {
                            for (int i = 0; i < shipLength; i++)
                            {
                                //Установка тега корабля
                                buttons[randomI, randomJ + i].Tag = 1;
                                buttons[randomI, randomJ + i].Background = brush;
                                //Установка тегов занятости
                                horizontalOccupation(i, buttons);
                            }
                            isShipSet = true;
                        }
                    }
                    else if (occupation == 1)
                    {
                        canSet = true;
                        for (int i = 0; i < shipLength; i++)
                            if (((int)buttons[randomI + i, randomJ].Tag == 1) ||
                                ((int)buttons[randomI + i, randomJ].Tag == 3))
                                canSet = false;
                        if (canSet)
                        {
                            for (int i = 0; i < shipLength; i++)
                            {
                                //Установка тега корабля
                                buttons[randomI + i, randomJ].Tag = 1;
                                buttons[randomI + i, randomJ].Background = brush;
                                //Установка тегов занятости
                                verticalOccupation(i, buttons);
                            }
                            isShipSet = true;
                        }
                    }
                }
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            playerHits = 0;
            enemyHits = 0;
            fieldFilled = true;
            clearWaterSpace(enemyButtons, false);
            fillFieldWithShips(enemyButtons, enemySeaColor);
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                    enemyButtons[i, j].IsEnabled = true;
            score.Content = playerHits + " : " + enemyHits;
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopButton.Content == MESSAGE_1)
            {
                for (int i = 0; i < SIZE; i++)
                    for (int j = 0; j < SIZE; j++)
                        if ((int)enemyButtons[i, j].Tag == 1)
                            enemyButtons[i, j].Background = enemyShipsColor;
                stopButton.Content = MESSAGE_2;
            }
            else
            {
                for (int i = 0; i < SIZE; i++)
                    for (int j = 0; j < SIZE; j++)
                        if (((int)enemyButtons[i, j].Tag == 1) && ((string)enemyButtons[i, j].Content != "*"))
                            enemyButtons[i, j].Background = enemySeaColor;
                stopButton.Content = MESSAGE_1;
            }
        }

        private void enemyOnClick(object sender, EventArgs eventArgs)
        {
            bool player_hit = false;
            var button = (Button)sender;
            if (((int)button.Tag == 1) && (button.Background != hittenColor)) 
            {
                player_hit = true;
                button.Background = hittenColor; 
                playerHits += 1; //Увеличение счетчика
                button.Content = "*";
            }
            else if (((int)button.Tag == 0) || ((int)button.Tag == 3)) // 0 - пустая клетка, 3 - рядом с кораблем
            {
                button.Content = "X";
            }
            if (playerHits == 20)
            {
                MessageBox.Show("Победа!");
                startButton.IsEnabled = false;
                fieldFilled = false;
                playerChosenButtonsCount = 0;
                playerHits = 0;
                enemyHits = 0;
                clearWaterSpace(playerButtons, true);
                clearWaterSpace(enemyButtons, false);
                score.Content = playerHits + " : " + enemyHits;
                return;
            }

            // Ход компьютера
            if (!player_hit)
            {
                bool endEnemyMove = false;
                while (!endEnemyMove)
                {
                    randomI = random.Next(0, SIZE);
                    randomJ = random.Next(0, SIZE);
                    if (((int)playerButtons[randomI, randomJ].Tag == 0) ||
                        ((int)playerButtons[randomI, randomJ].Tag == 3))
                    {
                        playerButtons[randomI, randomJ].Content = "*";
                        playerButtons[randomI, randomJ].Tag = 4;
                        endEnemyMove = true;
                    }
                    if ((int)playerButtons[randomI, randomJ].Tag == 1)
                    {
                        playerButtons[randomI, randomJ].Content = "*";
                        playerButtons[randomI, randomJ].Background = hittenColor;
                        playerButtons[randomI, randomJ].Tag = 4;
                        enemyHits += 1;
                        endEnemyMove = true;//
                    }
                    if (enemyHits == 20)
                    {
                        MessageBox.Show("Вы проиграли!");
                        startButton.IsEnabled = false;
                        fieldFilled = false;
                        playerChosenButtonsCount = 0;
                        playerHits = 0;
                        enemyHits = 0;
                        clearWaterSpace(playerButtons, true);
                        score.Content = playerHits + " : " + enemyHits;
                        return;
                    }
                }
            }
            score.Content = playerHits + " : " + enemyHits;
        }
       
            
    }
}
