# Implementing AES and Blowfish encryption techniques in minimal API

<p> In this small project, I developed an encrypted minimal API using AES and Blowfish encryption techniques.
This code sets up a .NET minimal API to demonstrate AES and Blowfish encryption. All the relevant codes and programs are in the APIEncrypt folder of this repository. Results are shown in the following screenshots.

<b><i>AES Encryption:</b></i> Uses a 256-bit key from the configuration file, with a randomly generated Initialization Vector (IV) for each encryption. It provides endpoints to show the plaintext, encrypted text, and decrypted text, including how IVs affect encryption.

<b><i>Blowfish Encryption:</b></i> Reads key from the configuration file and performs encryption and decryption using Blowfish with CBC mode. (This was developed with other github resources, which I have no reference to right now)

<b><i>Minimal API</b></i>: A streamlined way to define HTTP routes and handle requests with minimal boilerplate. The endpoints /Encryption/AES and /Encryption/Blowfish return JSON with encryption results.

<h5>AES endpoint with the same key, however, since IVs are randomly generated, notice how IV is different in each execution and how it affects the ciphertext.</h5>
<img width="959" alt="image" src="https://github.com/user-attachments/assets/4ea7c0e4-7b26-4d44-b5a6-1c6c9822a8df">
<img width="959" alt="image" src="https://github.com/user-attachments/assets/5e0ca264-1144-4a61-9145-8a3d15ef3406">

</br>

<h5>Blowfish endpoint with the same key. Similar to AES, IVs are randomly generated, and a different ciphertext is generated for the same plaintext and key.</h5>
<img width="959" alt="image" src="https://github.com/user-attachments/assets/61057444-da56-4a16-96d0-3dff879157af">
<img width="959" alt="image" src="https://github.com/user-attachments/assets/6ae6a97d-4784-4c13-9c15-386671b33f48">

</p>

</br>

<p> <h3>EncryptAES Class</h3>
The EncryptAES class is designed for AES encryption and decryption operations, implemented in a .NET environment. It utilizes AES (Advanced Encryption Standard) with a key length of 256 bits for robust security. Below is an overview of its functionality:

<ol>
<h4><li>Initialization of Key and IV:</li></h4>

<ul>
<li>Key: The class retrieves the AES key from a configuration file (appsettings.json). This is done for the simplicity of operating the code, a good key management system must be incorporated to properly store and retrieve keys. The key is to be Base64-encoded and of length 256 bits (32 bytes) for AES-256 encryption.</li>
<li>IV (Initialization Vector): The InitSymmetricEncryptionKeyIV method generates a random IV for each encryption operation, ensuring that the same plaintext encrypted multiple times will yield different ciphertexts. The IV is encoded in Base64 for easy handling and storage.</li>
</ul>

<h4><li>Key Extraction:</h4></li>
extractKeyValue(int len): This method reads the AES key from the configuration file, ensuring the key is correctly formatted for the encryption process. The key length provided here corresponds to AES-256 encryption.

<h4><li>Cipher Creation:</li></h4>
CreateCipher(string keyBase64): This method initializes an AES cipher object with CBC (Cipher Block Chaining) mode and ISO10126 padding. It converts the Base64-encoded key into a byte array suitable for the AES algorithm.

<h4><li>Encryption:</li></h4>
startEncrypt(string text, string IV, string key): Encrypts the provided plaintext using the specified IV and key. The encrypted output is returned as a Base64-encoded string. The method ensures that each encryption operation is unique due to the random IV.

<h4><li>Decryption:</li></h4>
Decrypt(string encryptedText, string IV, string key): Decrypts the Base64-encoded encrypted text using the provided IV and key. The method returns the original plaintext.

<h4><li>Output Format:</li></h4>
The results of encryption and decryption operations are displayed in JSON format via a minimal API, providing a clear and structured way to view the plaintext, encrypted text, and decrypted text.</p>

</ol>

Overall, by implementing AES, I learned various important topics in .NET minimal API and has advanced my skills in C#. I also learned how important it is to add IVs to enryption schemes to thwart various sophisticated cryptanalysis attacks.
</p>

<p><h3>EnryptBlowfish Class</h3>

The EncryptBlowFish class implements the Blowfish encryption algorithm in C#. Blowfish is a symmetric-key block cipher designed by Bruce Schneier, known for its simplicity and speed. This class supports encryption and decryption in various modes including CBC (Cipher Block Chaining), ECB (Electronic Codebook), and CTR (Counter) mode.

Key Features and Components:

<ol>
<h4><li>Key Management: </li></h4>
The class supports initialization with a hexadecimal string or a byte array. It sets up the key and initializes the Blowfish S-boxes and P-array using the key.

<h4><li>Encryption and Decryption:</h4></li>

<ul>
  <li>CBC Mode: Encrypts or decrypts data using a block cipher with a chaining mechanism, ensuring that each block of plaintext is XORed with the previous ciphertext block before encryption. The class manages the IV (Initialization Vector) which is crucial for CBC mode.</li>
  <li>ECB Mode: Encrypts or decrypts data without chaining. Each block of plaintext is encrypted independently.</li>
  <li>CTR Mode: Encrypts or decrypts data using a counter value combined with the plaintext through XOR operations.</li>
</ul>

<h4><li>Block Size: </li></h4>
Blowfish operates on 64-bit blocks of data, and this class handles padding and block operations accordingly.

<h4><li>IV Management: </li></h4>
The class can generate a random IV for CBC and CTR modes, ensuring that each encryption operation is unique even with the same key and plaintext.

<h4><li>Conversion Methods: </li></h4>
Includes utilities for converting between byte arrays and hexadecimal strings, facilitating easy input/output operations.

</ol>

Overall, this implementation of Blowfish provides a flexible and secure method for encrypting and decrypting data, suitable for scenarios where strong encryption is required. I also learned how the Blowfish algorithm works and how it is a good alternative to DES or 3DES.

</p>

<p><h3>Other Classes</h3>
<ul>
  <li>Configuration Class: The class defines the setters and getters for reading the key stored in appsettings.json file. We use this class to deserialize the JSON and create the readable object from JSON string</li>
  <li>ConvertToJson Class: This class defines variables that needs to be displayed in the JSON format and is used to output API results in JSON.</li>
  <li>Appsettings.json file: This file stores the keys for AES and Blowfish enryptions implemented. This is solely for simplicity purpose and not to be praticed in real     
      world</li>
</ul>
</p>
