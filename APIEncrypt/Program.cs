using System.Text.Json;
using APIEncrypt;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


ConvertToJson jsonFormat = new ConvertToJson(); //All returned output in minimal API needs to be in json format.


/*AES Encryption
IV is also displayed in the minimal API. IV should never be displayed as such. 
This is present here only to test out and analyze the IV associated with the encrypted text. 
The corresponding IV of an encrypted text if stored and not randomly generated, should also be encrypted.
*/

EncryptAES encrypt = new EncryptAES();

var (Key, IVBase64) = encrypt.InitSymmetricEncryptionKeyIV();

jsonFormat.Text1 = "Today I experimented and learned to implement AES encryption in minimal API.";
jsonFormat.EncryptedTextAes = encrypt.startEncrypt(jsonFormat.Text1, IVBase64, Key);
jsonFormat.DecryptedTextAes = encrypt.Decrypt(jsonFormat.EncryptedTextAes, IVBase64, Key);

jsonFormat.IVAes = IVBase64;
jsonFormat.EncryptedIVAes = encrypt.startEncrypt(jsonFormat.IVAes, IVBase64, Key);
jsonFormat.DecryptedIVAes = encrypt.Decrypt(jsonFormat.EncryptedIVAes, IVBase64, Key);


app.MapGet("/Encryption/AES", () => new {
    Text= jsonFormat.Text1,
    EncryptedText= jsonFormat.EncryptedTextAes,
    DecryptedText= jsonFormat.DecryptedTextAes,
    IV= jsonFormat.IVAes,
    EncryptedIV = jsonFormat.EncryptedIVAes,
    DecryptedIV= jsonFormat.DecryptedIVAes 
 
});



/*Blowfish Encryption
Reads key from configuration file by deserializing json file*/

string json = File.ReadAllText("appsettings.json");
Configuration config = JsonSerializer.Deserialize<Configuration>(json);

String keyBF = config.RandomValues.KeyBF;

EncryptBlowFish b = new EncryptBlowFish(keyBF);

jsonFormat.Text2 = "Today I experimented and learned to implement BlowFish encryption in minimal API.";

jsonFormat.EncryptedTextBF = b.Encrypt_CBC(jsonFormat.Text2);
jsonFormat.DecryptedTextBF = b.Decrypt_CBC(jsonFormat.EncryptedTextBF);


app.MapGet("/Encryption/Blowfish", () => new {
    Text = jsonFormat.Text2,
    EncryptedText = jsonFormat.EncryptedTextBF,
    DecryptedText = jsonFormat.DecryptedTextBF,

}) ;



app.Run();

