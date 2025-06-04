// See https://aka.ms/new-console-template for more information

using SixLetterWords;
using SixLetterWords.Services;

var txtFileProcessor = new TxtFileProcessor();
var app = new App(txtFileProcessor);
app.Run();
