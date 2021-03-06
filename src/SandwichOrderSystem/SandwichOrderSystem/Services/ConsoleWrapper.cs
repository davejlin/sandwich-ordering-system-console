﻿using System;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Services
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public ConsoleWrapper()
        {
            int width = (int)(0.01 * CONSOLE_WIDTH_PERCENTAGE_OF_MAX * Console.LargestWindowWidth);
            int height = (int) (0.01 * CONSOLE_HEIGHT_PERCENTAGE_OF_MAX * Console.LargestWindowHeight);
            Console.SetWindowSize(width, height);
        }

        public string ReadInput(string prompt, bool forceToLowercase = false)
        {
            Console.WriteLine();
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            return forceToLowercase ? input.ToLower() : input;
        }

        public void ClearOutput()
        {
            Console.Clear();
        }

        public void Output(string message)
        {
            Console.Write(message);
        }

        public void Output(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        public void OutputLine(string message, bool outputBlankLineBeforeMessage = true)
        {
            if (outputBlankLineBeforeMessage)
            {
                Console.WriteLine();
            }
            Console.WriteLine(message);
        }

        public void OutputLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        public void OutputBlankLine()
        {
            Console.WriteLine();
        }
    }
}
