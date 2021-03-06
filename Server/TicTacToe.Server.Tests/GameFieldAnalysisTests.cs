﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacToe.Shared;

namespace TicTacToe.Server.Tests
{
    [TestFixture]
    public sealed class GameFieldAnalysisTests
    {
        private IAnalysis m_analysis = default;

        [SetUp]
        public void Initialize()
        {
            m_analysis = new GameFieldAnalysis();
        }

        [Test]
        public void NoWinOne()
        {
            CellModel[,] field =
            {
                {null, null, null},
                {null, null, null},
                {null, null, null}
            };
            bool win = m_analysis.WinnerDefiner(field, out _);
            Assert.IsFalse(win);
        }

        [Test]
        public void NoWinTwo()
        {
            CellModel[,] field =
            {
                {new CellModel(Symbols.X), new CellModel(Symbols.X), new CellModel(Symbols.O)},
                {null, new CellModel(Symbols.X), null},
                {new CellModel(Symbols.O), null, new CellModel(Symbols.O)}
            };
            bool win = m_analysis.WinnerDefiner(field, out _);
            Assert.IsFalse(win);
        }

        [Test]
        public void HorizontalTestOne()
        {
            //XOO
            //HXO
            //HHX


            CellModel[,] field =
            {
                {null, null, new CellModel(Symbols.X)},
                {null, new CellModel(Symbols.X), new CellModel(Symbols.O)},
                {new CellModel(Symbols.X), new CellModel(Symbols.O), new CellModel(Symbols.O)}
            };
            bool win = m_analysis.WinnerDefiner(field, out _);
            Assert.IsTrue(win);
        }

        [Test]
        public void HorizontalTestTwo()
        {
            CellModel[,] field =
            {
                {null, null, null},
                {new CellModel(Symbols.X), new CellModel(Symbols.X), new CellModel(Symbols.X)},
                {null, null, null}
            };
            bool win = m_analysis.WinnerDefiner(field, out _);
            Assert.IsTrue(win);
        }

        [Test]
        public void HorizontalTestThree()
        {
            CellModel[,] field =
            {
                {null, null, null},
                {null, null, null},
                {new CellModel(Symbols.X), new CellModel(Symbols.X), new CellModel(Symbols.X)}
            };
            bool win = m_analysis.WinnerDefiner(field, out _);
            Assert.IsTrue(win);
        }

        [Test]
        public void DiagonalTestOne()
        {
            CellModel[,] field =
            {
                {new CellModel(Symbols.X), null, null},
                {null, new CellModel(Symbols.X), null},
                {new CellModel(Symbols.O), new CellModel(Symbols.X), new CellModel(Symbols.X)}
            };
            bool win = m_analysis.WinnerDefiner(field, out _);
            Assert.IsTrue(win);
        }
        [Test]
        public void DiagonalTestTwo()
        {
            CellModel[,] field =
            {
                {new CellModel(Symbols.X), new CellModel(Symbols.O), new CellModel(Symbols.O)},
                {null, new CellModel(Symbols.X), null},
                {null, null, new CellModel(Symbols.X)}
            };
            bool win = m_analysis.WinnerDefiner(field, out IEnumerable<(int, int)> result);
            Assert.IsTrue(win);
            Assert.IsTrue(result.Any());
        }



        [Test]
        public void DiagonalTestThree()
        {
            CellModel[,] field =
            {
                {null, null, new CellModel(Symbols.X)},
                {null, new CellModel(Symbols.X), null},
                {new CellModel(Symbols.X), new CellModel(Symbols.O), new CellModel(Symbols.O)}
            };
            bool win = m_analysis.WinnerDefiner(field, out IEnumerable<(int, int)> result);
            Assert.IsTrue(win);
            Assert.IsTrue(result.Any());
        }
    }
}