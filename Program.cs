// See https://aka.ms/new-console-template for more information

using SixLetterWords;
using SixLetterWords.Services;

var txtFileProcessor = new TxtFileProcessor();
var wordCombinationSeeker = new WordCombinationSeeker();
var wordPrinter = new WordPrinter();

var app = new App(txtFileProcessor, wordCombinationSeeker, wordPrinter);
app.Run();
