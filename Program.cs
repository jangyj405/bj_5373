using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public static class Program
{
    public class Cube
    {
        static void InitArray(char v, out char[,] arr, int size)
        {
            arr = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = v;
                }
            }
        }
        public Cube()
        {
            functionset.Add('U', RotateUpper);
            functionset.Add('D', RotateBottom);
            functionset.Add('L', RotateLeft);
            functionset.Add('R', RotateRight);
            functionset.Add('F', RotateForward);
            functionset.Add('B', RotateBackward);
        }
        public void InitCube()
        {
            InitArray('w', out upper, 3);
            InitArray('y', out bottom, 3);
            InitArray('r', out forward, 3);
            InitArray('o', out backward, 3);
            InitArray('g', out left, 3);
            InitArray('b', out right, 3);
        }
        Dictionary<char, Action<char>> functionset = new Dictionary<char, Action<char>>();
        public void RotateUpper(char direction)
        {
            RotateSelf(ref upper, direction);
            if (direction == '+')
            {
                char[] tmp = { left[0, 0], left[0, 1], left[0, 2] };
                left[0, 0] = forward[0, 0];
                left[0, 1] = forward[0, 1];
                left[0, 2] = forward[0, 2];
                forward[0, 0] = right[0, 0];
                forward[0, 1] = right[0, 1];
                forward[0, 2] = right[0, 2];
                right[0, 0] = backward[0, 0];
                right[0, 1] = backward[0, 1];
                right[0, 2] = backward[0, 2];
                backward[0, 0] = tmp[0];
                backward[0, 1] = tmp[1];
                backward[0, 2] = tmp[2];
            }
            else
            {
                char[] tmp = { left[0, 0], left[0, 1], left[0, 2] };
                left[0, 0] = backward[0, 0];
                left[0, 1] = backward[0, 1];
                left[0, 2] = backward[0, 2];
                backward[0, 0] = right[0, 0];
                backward[0, 1] = right[0, 1];
                backward[0, 2] = right[0, 2];
                right[0, 0] = forward[0, 0];
                right[0, 1] = forward[0, 1];
                right[0, 2] = forward[0, 2];
                forward[0, 0] = tmp[0];
                forward[0, 1] = tmp[1];
                forward[0, 2] = tmp[2];
            }
        }
        public void RotateBottom(char direction)
        {
            RotateSelf(ref bottom, direction);
            if (direction == '-')
            {
                char[] tmp = { left[2, 0], left[2, 1], left[2, 2] };
                left[2, 0] = forward[2, 0];
                left[2, 1] = forward[2, 1];
                left[2, 2] = forward[2, 2];
                forward[2, 0] = right[2, 0];
                forward[2, 1] = right[2, 1];
                forward[2, 2] = right[2, 2];
                right[2, 0] = backward[2, 0];
                right[2, 1] = backward[2, 1];
                right[2, 2] = backward[2, 2];
                backward[2, 0] = tmp[0];
                backward[2, 1] = tmp[1];
                backward[2, 2] = tmp[2];
            }
            else
            {
                char[] tmp = { left[2, 0], left[2, 1], left[2, 2] };
                left[2, 0] = backward[2, 0];
                left[2, 1] = backward[2, 1];
                left[2, 2] = backward[2, 2];
                backward[2, 0] = right[2, 0];
                backward[2, 1] = right[2, 1];
                backward[2, 2] = right[2, 2];
                right[2, 0] = forward[2, 0];
                right[2, 1] = forward[2, 1];
                right[2, 2] = forward[2, 2];
                forward[2, 0] = tmp[0];
                forward[2, 1] = tmp[1];
                forward[2, 2] = tmp[2];
            }
        }
        public void RotateForward(char direction)
        {
            RotateSelf(ref forward, direction);
            if (direction == '+')
            {
                char[] tmp = { upper[2, 0], upper[2, 1], upper[2, 2] };
                upper[2, 0] = left[2, 2];
                upper[2, 1] = left[1, 2];
                upper[2, 2] = left[0, 2];
                left[2, 2] = bottom[0, 2];
                left[1, 2] = bottom[0, 1];
                left[0, 2] = bottom[0, 0];
                bottom[0, 2] = right[0, 0];
                bottom[0, 1] = right[1, 0];
                bottom[0, 0] = right[2, 0];
                right[0, 0] = tmp[0];
                right[1, 0] = tmp[1];
                right[2, 0] = tmp[2];
            }
            else
            {
                char[] tmp = { upper[2, 0], upper[2, 1], upper[2, 2] };
                upper[2, 0] = right[0, 0];
                upper[2, 1] = right[1, 0];
                upper[2, 2] = right[2, 0];
                right[0, 0] = bottom[0, 2];
                right[1, 0] = bottom[0, 1];
                right[2, 0] = bottom[0, 0];
                bottom[0, 2] = left[2, 2];
                bottom[0, 1] = left[1, 2];
                bottom[0, 0] = left[0, 2];
                left[2, 2] = tmp[0];
                left[1, 2] = tmp[1];
                left[0, 2] = tmp[2];
            }
        }
        public void RotateBackward(char direction)
        {
            RotateSelf(ref backward, direction);
            if (direction == '+')
            {
                char[] tmp = { upper[0, 0], upper[0, 1], upper[0, 2] };
                upper[0, 0] = right[0, 2];
                upper[0, 1] = right[1, 2];
                upper[0, 2] = right[2, 2];
                right[0, 2] = bottom[2, 2];
                right[1, 2] = bottom[2, 1];
                right[2, 2] = bottom[2, 0];
                bottom[2, 2] = left[2, 0];
                bottom[2, 1] = left[1, 0];
                bottom[2, 0] = left[0, 0];
                left[2, 0] = tmp[0];
                left[1, 0] = tmp[1];
                left[0, 0] = tmp[2];
            }
            else
            {
                char[] tmp = { upper[0, 0], upper[0, 1], upper[0, 2] };
                upper[0, 0] = left[2, 0];
                upper[0, 1] = left[1, 0];
                upper[0, 2] = left[0, 0];
                left[2, 0] = bottom[2, 2];
                left[1, 0] = bottom[2, 1];
                left[0, 0] = bottom[2, 0];
                bottom[2, 2] = right[0, 2];
                bottom[2, 1] = right[1, 2];
                bottom[2, 0] = right[2, 2];
                right[0, 2] = tmp[0];
                right[1, 2] = tmp[1];
                right[2, 2] = tmp[2];
            }
        }
        public void RotateLeft(char direction)
        {
            RotateSelf(ref left, direction);
            if (direction == '+')
            {
                char[] tmp = { upper[0, 0], upper[1, 0], upper[2, 0] };
                upper[0, 0] = backward[2, 2];
                upper[1, 0] = backward[1, 2];
                upper[2, 0] = backward[0, 2];
                backward[2, 2] = bottom[0, 0];
                backward[1, 2] = bottom[1, 0];
                backward[0, 2] = bottom[2, 0];
                bottom[0, 0] = forward[0, 0];
                bottom[1, 0] = forward[1, 0];
                bottom[2, 0] = forward[2, 0];
                forward[0, 0] = tmp[0];
                forward[1, 0] = tmp[1];
                forward[2, 0] = tmp[2];
            }
            else
            {
                char[] tmp = { upper[0, 0], upper[1, 0], upper[2, 0] };
                upper[0, 0] = forward[0, 0];
                upper[1, 0] = forward[1, 0];
                upper[2, 0] = forward[2, 0];
                forward[0, 0] = bottom[0, 0];
                forward[1, 0] = bottom[1, 0];
                forward[2, 0] = bottom[2, 0];
                bottom[0, 0] = backward[2, 2];
                bottom[1, 0] = backward[1, 2];
                bottom[2, 0] = backward[0, 2];
                backward[2, 2] = tmp[0];
                backward[1, 2] = tmp[1];
                backward[0, 2] = tmp[2];
            }
        }
        public void RotateRight(char direction)
        {
            RotateSelf(ref right, direction);
            if (direction == '+')
            {
                char[] tmp = { upper[2, 2], upper[1, 2], upper[0, 2] };
                upper[2, 2] = forward[2, 2];
                upper[1, 2] = forward[1, 2];
                upper[0, 2] = forward[0, 2];
                forward[2, 2] = bottom[2, 2];
                forward[1, 2] = bottom[1, 2];
                forward[0, 2] = bottom[0, 2];
                bottom[2, 2] = backward[0, 0];
                bottom[1, 2] = backward[1, 0];
                bottom[0, 2] = backward[2, 0];
                backward[0, 0] = tmp[0];
                backward[1, 0] = tmp[1];
                backward[2, 0] = tmp[2];
            }
            else
            {
                char[] tmp = { upper[2, 2], upper[1, 2], upper[0, 2] };
                upper[2, 2] = backward[0, 0];
                upper[1, 2] = backward[1, 0];
                upper[0, 2] = backward[2, 0];
                backward[0, 0] = bottom[2, 2];
                backward[1, 0] = bottom[1, 2];
                backward[2, 0] = bottom[0, 2];
                bottom[2, 2] = forward[2, 2];
                bottom[1, 2] = forward[1, 2];
                bottom[0, 2] = forward[0, 2];
                forward[2, 2] = tmp[0];
                forward[1, 2] = tmp[1];
                forward[0, 2] = tmp[2];
            }
        }
        void RotateSelf(ref char[,] aspect, char direction)
        {
            char[,] matrix = new char[3, 3];
            if (direction == '-')
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        matrix[i, j] = aspect[j, 3 - i - 1];
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        matrix[i, j] = aspect[3 - j - 1, i];
                    }
                }
            }
            aspect = matrix;
        }
        public void Rotate(char command, char direction)
        {
            functionset[command](direction);
        }
        public char[,] Upper
        {
            get {
                return upper;
            }
        }
        public char[,] upper = new char[3, 3];
        public char[,] bottom = new char[3, 3];
        public char[,] forward = new char[3, 3];
        public char[,] backward = new char[3, 3];
        public char[,] left = new char[3, 3];
        public char[,] right = new char[3, 3];
    }
    public static void Main(string[] args)
    {
        var tcNum = int.Parse(Console.ReadLine() ?? "");
        List<List<string>> testCases = new List<List<string>>();
        for (int i = 0; i < tcNum; i++)
        {
            Console.ReadLine();
            var str = (Console.ReadLine() ?? "").Split(" ");
            List<string> tc = new List<string>();
            tc.AddRange(str);
            testCases.Add(tc);
        }
        Cube c = new Cube();
        for (int i = 0; i < testCases.Count; i++)
        {
            c.InitCube();
            for (int j = 0; j < testCases[i].Count; j++)
            {
                c.Rotate(testCases[i][j][0], testCases[i][j][1]);
            }
            TempPrint(c.Upper);
        }
    }

    public static void TempPrint(char[,] temp)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(temp[i, j]);
            }
            Console.WriteLine();
        }
    }
}