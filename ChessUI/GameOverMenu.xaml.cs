﻿using ChessLogic;
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

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {

        public event Action<Option> OptionSelected;
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "Alb a Câștigat!",
                Player.Black => "Negru a Câștigat!",
                _ => "Egalitate!"
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "Alb",
                Player.Black => "Negru",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason reason, Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Stalemate => $"STAGNARE - {PlayerString(currentPlayer)} NU SE MAI POT FACE MIȘCĂRI",
                EndReason.Checkmate => $"ȘAH MAT - {PlayerString(currentPlayer)} NU SE MAI POT FACE MIȘCĂRI",
                EndReason.FiftyMoveRule => "REGULA DE 50 DE MIȘCĂRI",
                EndReason.InsufficientMaterial => "MATERIAL INSUFICIENT",
                EndReason.ThreefoldRepetition => "REPETIȚIE TRIPLĂ",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
