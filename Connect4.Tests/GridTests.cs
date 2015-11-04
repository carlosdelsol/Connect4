using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Connect4.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void On_a_new_grid_bottom_left_cell_must_be_empty()
        {
            var grid = new Grid();
            Assert.AreEqual(Grid.States.Empty, grid.getCellStates(0, 0));
        }

        [TestMethod]
        public void When_I_put_red_token_in_the_left_column_left_cell_must_be_red()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Red, grid.getCellStates(0, 0));
        }

        [TestMethod]
        public void When_I_put_yellow_token_in_the_left_column_left_cell_must_be_yellow()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Yellow);
            Assert.AreEqual(Grid.States.Yellow, grid.getCellStates(0, 0));
        }
        [TestMethod]
        public void When_I_put_red_token_in_the_left_column_the_bottom_of_the_second_column_must_be_empty()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Empty, grid.getCellStates(1, 0));
        }
        
        [TestMethod]
        public void When_I_put_a_red_token_in_first_column_second_row_is_empty()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Empty, grid.getCellStates(0, 1));
        }
        [TestMethod]
        public void When_I_put_two_red_token_in_first_column_second_row_is_red()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Red, grid.getCellStates(0, 1));
        }
        [TestMethod]
        public void When_I_put_three_red_token_in_first_column_third_row_is_red()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Red, grid.getCellStates(0, 2));
        }

        [TestMethod]
        public void When_I_put_a_seven_tokens_in_the_same_column_the_state_is_full()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.FullColumn, grid.getCellStates(0, 6));
        }
        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_column_Check_if_there_is_not_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_column_Check_if_there_is_not_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Yellow);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Yellow));
        }
        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_column_Check_if_there_is_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(0, Grid.Colors.Red);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_column_Check_if_there_is_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Yellow);
            grid.insertToken(0, Grid.Colors.Yellow);
            grid.insertToken(0, Grid.Colors.Yellow);
            grid.insertToken(0, Grid.Colors.Yellow);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Yellow));
        }

        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_row_Check_if_there_is_not_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_row_Check_if_there_is_not_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Yellow);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Yellow));
        }


        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_row_Check_if_there_is_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Red);
            grid.insertToken(1, Grid.Colors.Red);
            grid.insertToken(2, Grid.Colors.Red);
            grid.insertToken(3, Grid.Colors.Red);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_row_Check_if_there_is_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.insertToken(0, Grid.Colors.Yellow);
            grid.insertToken(1, Grid.Colors.Yellow);
            grid.insertToken(2, Grid.Colors.Yellow);
            grid.insertToken(3, Grid.Colors.Yellow);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Yellow));
        }


        [TestMethod]
        public void When_I_put_three_red_token_from_right_to_felt_diagonal_in_middle_down_part_Check_there_is_not_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(3, 0, Grid.Colors.Red);
            grid.insertPosition(5, 2, Grid.Colors.Red);
            grid.insertPosition(6, 3, Grid.Colors.Red);
            Assert.IsFalse(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_four_red_token_from_right_to_left_diagonal_in_middle_down_part_Check_there_is_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(3, 0, Grid.Colors.Red);
            grid.insertPosition(4, 1, Grid.Colors.Red);
            grid.insertPosition(5, 2, Grid.Colors.Red);
            grid.insertPosition(6, 3, Grid.Colors.Red);
            Assert.IsTrue(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_four_red_token_in_random_position_from_right_to_left_diagonal_in_middle_down_part_Check_there_is_not_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(0, 1, Grid.Colors.Red);
            grid.insertPosition(0, 0, Grid.Colors.Red);
            grid.insertPosition(4, 2, Grid.Colors.Red);
            grid.insertPosition(5, 0, Grid.Colors.Red);
            Assert.IsFalse(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_three_red_token_from_right_to_left_diagonal_in_middle_upper_part_Check_there_is_not_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(0, 2, Grid.Colors.Red);
            grid.insertPosition(1, 3, Grid.Colors.Red);
            grid.insertPosition(3, 5, Grid.Colors.Red);
            Assert.IsFalse(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_four_red_token_from_right_to_left_diagonal_in_middle_upper_part_Check_there_is_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(0, 2, Grid.Colors.Red);
            grid.insertPosition(1, 3, Grid.Colors.Red);
            grid.insertPosition(2, 4, Grid.Colors.Red);
            grid.insertPosition(3, 5, Grid.Colors.Red);
            Assert.IsTrue(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_four_red_token_in_random_position_from_right_to_left_diagonal_in_middle_upper_part_Check_there_is_not_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(0, 2, Grid.Colors.Red);
            grid.insertPosition(5, 2, Grid.Colors.Red);
            grid.insertPosition(2, 4, Grid.Colors.Red);
            grid.insertPosition(3, 4, Grid.Colors.Red);
            Assert.IsFalse(grid.analyzeDiagonal(Grid.Colors.Red));
        }


        [TestMethod]
        public void When_I_put_three_red_token_from_left_to_right_diagonal_in_middle_down_part_Check_there_is_not_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(3, 0, Grid.Colors.Red);
            grid.insertPosition(5, 2, Grid.Colors.Red);
            grid.insertPosition(6, 3, Grid.Colors.Red);
            Assert.IsFalse(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_four_red_token_from_left_to_right_diagonal_in_middle_down_part_Check_there_is_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(0, 3, Grid.Colors.Red);
            grid.insertPosition(1, 2, Grid.Colors.Red);
            grid.insertPosition(2, 1, Grid.Colors.Red);
            grid.insertPosition(3, 0, Grid.Colors.Red);
            Assert.IsTrue(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_four_red_token_from_left_to_right_diagonal_in_middle_up_part_Check_there_is_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(3, 5, Grid.Colors.Red);
            grid.insertPosition(4, 4, Grid.Colors.Red);
            grid.insertPosition(5, 3, Grid.Colors.Red);
            grid.insertPosition(6, 2, Grid.Colors.Red);
            Assert.IsTrue(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_four_red_token_from_left_to_right_diagonal_in_middle_up_part_Check_there_is_diagonal_combination_2()
        {
            var grid = new Grid();
            grid.insertPosition(6, 0, Grid.Colors.Red);
            grid.insertPosition(5, 1, Grid.Colors.Red);
            grid.insertPosition(4, 2, Grid.Colors.Red);
            grid.insertPosition(3, 3, Grid.Colors.Red);
            Assert.IsTrue(grid.analyzeDiagonal(Grid.Colors.Red));
        }

        [TestMethod]
        public void When_I_put_four_red_token_in_random_position_from_left_to_right_diagonal_in_middle_upper_part_Check_there_is_not_diagonal_combination()
        {
            var grid = new Grid();
            grid.insertPosition(0, 2, Grid.Colors.Red);
            grid.insertPosition(5, 2, Grid.Colors.Red);
            grid.insertPosition(1, 4, Grid.Colors.Red);
            grid.insertPosition(3, 4, Grid.Colors.Red);
            Assert.IsFalse(grid.analyzeDiagonal(Grid.Colors.Red));
        }
        [TestMethod]
        public void When_state_is_OutOfRange_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.States.OutOfRange), "Please, write a number between 1 to 7");
        }
        [TestMethod]
        public void When_state_is_InvalidCharacter_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.States.InvalidCharacter), "Invalid character. Please, write a number between 1 to 7");
        }
        [TestMethod]
        public void When_state_is_FullColumn_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.States.FullColumn), "This column is full, try another column");
        }
        [TestMethod]
        public void When_state_is_FullGrid_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.States.FullGrid), "The grid is full. Nobody wins.");
        }

        [TestMethod]
        public void When_state_select_columns_and_color_is_Red_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.Colors.Red, Grid.States.SelectAColumn), "(RED) - Select a column [1-7]:");
        }
        [TestMethod]
        public void When_state_is_Select_Column_and_Color_is_Yellow_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.Colors.Yellow, Grid.States.SelectAColumn), "(YELLOW) - Select a column [1-7]:");
        }
        [TestMethod]
        public void When_Colors_is_Red_and_State_is_Win_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.Colors.Red, Grid.States.Win), "(RED) - WINS!");
        }
        [TestMethod]
        public void When_Colors_is_Yellow_and_State_is_Win_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.Colors.Yellow, Grid.States.Win), "(YELLOW) - WINS!");
        }
        [TestMethod]
        public void When_state_is_AwaitingRed_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.States.AwaitingRed), "Awaiting Red");
        }
        [TestMethod]
        public void When_state_is_AwaitingYellow_print_message_in_screen()
        {
            var grid = new Grid();
            Assert.AreEqual(grid.showMessage(Grid.States.AwaitingYellow), "Awaiting Yellow");
        }


        [TestMethod]
        public void When_A_Bigger_Limit_Is_Inputed_A_Message_Is_Shown()
        {
            var mock = Substitute.For<IPrinter>();
            var grid = new Grid(mock);
            grid.insertToken(8, Grid.Colors.Red);
            mock.Received().PrintLine("Please, write a number between 1 to 7");
        }

        [TestMethod]
        public void When_A_Smaller_Limit_Is_Inputed_A_Message_Is_Shown()
        {
            var mock = Substitute.For<IPrinter>();
            var grid = new Grid(mock);
            grid.insertToken(-1, Grid.Colors.Red);
            mock.Received().PrintLine("Please, write a number between 1 to 7");
        }
    }
}
