using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Red, grid.getCellStates(0, 0));
        }

        [TestMethod]
        public void When_I_put_yellow_token_in_the_left_column_left_cell_must_be_yellow()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Yellow);
            Assert.AreEqual(Grid.States.Yellow, grid.getCellStates(0, 0));
        }
        [TestMethod]
        public void When_I_put_red_token_in_the_left_column_the_bottom_of_the_second_column_must_be_empty()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Empty, grid.getCellStates(1, 0));
        }
        [TestMethod]
        public void When_I_put_a_token_in_the_minus_one_it_is_impossible()
        {
            var grid = new Grid();
            grid.InsertToken(-1, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.OutOfRange, grid.getCellStates(-1, 0));
        }
        [TestMethod]
        public void When_I_put_a_token_in_the_bigger_six_column_it_is_impossible()
        {
            var grid = new Grid();
            grid.InsertToken(7, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.OutOfRange, grid.getCellStates(7, 0));
        }
        [TestMethod]
        public void When_I_put_a_red_token_in_first_column_second_row_is_empty()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Empty, grid.getCellStates(0, 1));
        }
        [TestMethod]
        public void When_I_put_two_red_token_in_first_column_second_row_is_red()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Red, grid.getCellStates(0, 1));
        }
        [TestMethod]
        public void When_I_put_three_red_token_in_first_column_third_row_is_red()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.Red, grid.getCellStates(0, 2));
        }

        [TestMethod]
        public void When_I_put_a_seven_tokens_in_the_same_column_the_state_is_full()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.AreEqual(Grid.States.FullColumn, grid.getCellStates(0, 6));
        }
        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_column_Check_if_there_is_not_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_column_Check_if_there_is_not_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Yellow);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Yellow));
        }
        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_column_Check_if_there_is_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_column_Check_if_there_is_vertical_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Yellow);
            grid.InsertToken(0, Grid.Colors.Yellow);
            grid.InsertToken(0, Grid.Colors.Yellow);
            grid.InsertToken(0, Grid.Colors.Yellow);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Vertical, Grid.Colors.Yellow));
        }

        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_row_Check_if_there_is_not_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_row_Check_if_there_is_not_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Yellow);
            Assert.IsFalse(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Yellow));
        }
        [TestMethod]
        public void When_I_put_one_red_token_in_the_first_row_Check_if_there_is_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Red);
            grid.InsertToken(1, Grid.Colors.Red);
            grid.InsertToken(2, Grid.Colors.Red);
            grid.InsertToken(3, Grid.Colors.Red);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Red));
        }
        [TestMethod]
        public void When_I_put_one_yellow_token_in_the_first_row_Check_if_there_is_horizontal_combination_in_the_first_column()
        {
            var grid = new Grid();
            grid.InsertToken(0, Grid.Colors.Yellow);
            grid.InsertToken(1, Grid.Colors.Yellow);
            grid.InsertToken(2, Grid.Colors.Yellow);
            grid.InsertToken(3, Grid.Colors.Yellow);
            Assert.IsTrue(grid.checkAnalyze(0, Grid.Direction.Horizontal, Grid.Colors.Yellow));
        }
    }
}
