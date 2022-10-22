# Demo Code 

This is the demo code for the EvolveUI port of Unity's Dragon Crashers [(video here)](https://www.youtube.com/watch?v=LsttlNW7HlQ)

This is ONLY the UI and style code, it does not include any assets, a Unity project, the EvolveUI compiler or the EvolveUI runtime. 

This code is heavily commented and is intended to give you a sense of how a somewhat complex EvolveUI project is put together. 

I would recommend having a look at the following files:

- [App.ui](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/App.ui)
- [SideMenu.ui](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/SideMenu/SideMenu.ui)
- [HeroScreen.ui](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/Screens/Heroes/HeroScreen.ui)
- [InventoryOverlay.ui](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/Overlay/InventoryOverlay.ui)
- [SkillSection.ui](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/Screens/Heroes/SkillSection.ui)
- [Dropdown.ui](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/Primitives/Dropdown/Dropdown.ui)
- [Dropdown.cs](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/App.ui)

## Highlighting

#### Rider
If you want to open the files in Rider you can download the EvolveUI plugin [here](https://drive.google.com/uc?id=1HeBR_udYp4gYaLhWQtUAavpJ4-CNEomQ&export=download). You can then drag & drop the zip file into any Rider window, restart Rider, and you're good to go. 
The Rider plugin has features such as go-to-reference, code completion, refactoring, and a lot more. 

#### VS Code
If you aren't using the Rider plugin, the easiest way to view the files is to open this repo in the Visual Studio Code for github site [(click here)](https://github1s.com/EvolveGameTools/DragonCrashersDemoCode/blob/master/UI/App.ui)

While there isn't a VS Code plugin for EvolveUI yet, you can associate `.ui` and `.style` files with C# for somewhat reasonable (but not 100% correct) highlighting. 

Once VS Code is open, press `Ctrl+Shift+P` and type "change language mode" with a `.ui` or `.style` file open and select `C#`. You will need to do this twice, once for `.ui` files and once for `.style` files

## Documentation

EvolveUI's documentation site can be found [here](https://evolvegametools.github.io/EvolveUIDocs/docs/templates/template_syntax). It's not complete and certainly not polished but may still be helpful to browse. Here are some of the more interesting links to check out:

- [Template Syntax](https://evolvegametools.github.io/EvolveUIDocs/docs/templates/template_syntax)
- [Style Syntax](https://evolvegametools.github.io/EvolveUIDocs/docs/templates/style_syntax)
- [Style Queries](https://evolvegametools.github.io/EvolveUIDocs/docs/templates/style_queries)
- [Style Properties](https://evolvegametools.github.io/EvolveUIDocs/docs/styles/style_properties_generated)
- [Style Types](https://evolvegametools.github.io/EvolveUIDocs/docs/styles/style_types_generated)



