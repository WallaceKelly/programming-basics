cipherText = input("enter encrypted message: ")
shiftNumber = int(input("enter shift number: "))

unshiftedText = cipherText
shiftedText = ''

for char in unshiftedText: 
  if char == ' ':
    shiftedText = shiftedText + char
  elif char.isupper():
    shiftedText = shiftedText + chr((ord(char) + shiftNumber - 65) % 26 + 65)
  else:
    shiftedText = shiftedText + chr((ord(char) + shiftNumber - 97) % 26 + 97)

clearText = shiftedText
print("decrypted message: ", clearText)

