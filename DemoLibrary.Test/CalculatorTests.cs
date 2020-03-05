﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;

namespace DemoLibrary.Test
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4, 3,7)]
        [InlineData(21, 5.25, 26.25)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        public void Add_SimpleValuesShouldCalculate( double x, double y, double expected)
        {
            // Arrange
            //double expected = 5;

            // Act 
            double actual = Calculator.Add(x, y);

            //Assert 
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8,4,2)]
        public void Devide_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            //Arrange
            
            //Act
            double actual = Calculator.Divide(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Devide_DevideByZero()
        {
            //Arrange
            double expected = 0; 
            //Act
            double actual = Calculator.Divide(15, 0);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

