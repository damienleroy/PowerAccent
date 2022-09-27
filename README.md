# How it works

Press and hold a letter that supports diacritic marks, then press space bar or arrow key to select the accent. For example <kbd>E</kbd> + <kbd>Space</kbd>. With spacebar, repeat presses to change accent mark. When releasing the letter key, the accented letter is inserted.

The software is currently working with the most of accents for several (Latin script based) countries, including **Czech**, **German**, **France**, **Maori** and many others. The list can be found in [Languages.cs](/PowerAccent.Core/Languages.cs).
If any language is missing, don't hesitate to create an [issue](/issues).

All letters are sorted by usage frequency by default, as found on [Wikipedia](https://wikipedia.org/wiki/Letter_frequency).

# Download

See the [Release](/releases) page.

# Known problems

- Some keys can have interference with some actions or some tools
<!-- examples would be welcome here -->
- (Experimental feature) Inside browsers and some other software, the tool can't detect the caret position. Default position is applied, meaning center top of the main window/display
<!-- which one is it? -->

# The future

- More letters and accents
- Theme and design improvement
- Some other [asked features](/issues)

# PowerToys
PowerAccent has been implemented in PowerToys and renamed as QuickAccent. Both have globally the same features and offers different experiences in the usage (taskbar icon, and different settings view).

# If you like it

https://www.buymeacoffee.com/dams


# Thanks to

- [Ciantic](https://gist.github.com/Ciantic/471698) for the implementation of the Keyboard Listener.
- [Saurabh Singh](https://www.codeproject.com/Articles/34520/Getting-Caret-Position-Inside-Any-Application) to share how get the caret position.
- [PowerToys team](https://github.com/microsoft/PowerToys) to integrated PowerAccent in PowerToys (named as Quick Accent).
