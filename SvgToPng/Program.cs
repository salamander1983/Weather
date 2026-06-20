using System;
using System.Drawing.Imaging;
using System.IO;

using Svg;

const int width = 128;
const string inputFolder = "IconsSvg";
const string outputFolder = "IconsPng";

ClearFolder(outputFolder);

var files = Directory.GetFiles(inputFolder, "*.svg");
foreach (var inputPath in files)
{
    var fileName = inputPath.Split('\\')[^1].Replace(".svg", ".png");
    var outputPath = $"{outputFolder}/{fileName}";
    
    ConvertSvgToPng(inputPath, outputPath, width);

    PrintInfo(inputPath, outputPath);
}

static void ClearFolder(string outputFolder)
{
    if (Directory.Exists(outputFolder))
        Directory.Delete(outputFolder, recursive: true);
    Directory.CreateDirectory(outputFolder);
}

static void ConvertSvgToPng(string inputPath, string outputPath, int width)
{    
    var svg = SvgDocument.Open(inputPath);
    var bitmap = svg.Draw(width, 0);
    bitmap.Save(outputPath, ImageFormat.Png);
}

static void PrintInfo(string inputPath, string outputPath)
{
    var from = $"Converted {inputPath}";
    from = from.PadRight(40);
    var to = $" ->    {outputPath}";
    Console.WriteLine(from + to);
}
