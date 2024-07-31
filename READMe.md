## Introduction

This solution shows how precise sizing of UI elements can be done without having to take into account the sizes of all the different bars that are available on the different platforms.

I have included the most important part of the source code that I used for my mobile application Smart Letter Baord, which can be found on
https://smartletterboard.com

# Problem
For Smart Letter Board it was very important that the keys on the screen were as big as possible on both phone and tablet. 
I also wanted to give the user the possibility to select from different page layouts to make it even fit better; one with the number on top, one with a numeric pad on the right, and one without numbers.
On desktop the screen element should resize when the application is resized.


# Architecture
The architecture is copied from the original project, taking into account that I want the different components as loosely coupled as possible.

ResizeMAUI.Models
Models generated with EF Core, extensions and everything model related on project level

ResizeMAUI.ObservableModels
These models in this project needed to be observable. Changes on these models should trigger an UI refresh. 

ResizeMAUI.ViewModels
This contains the MainViewModel that is used to tie everything together. This uses the Community.Toolkit.Mvvm for Observability.

ResizeMAUI.Application.Maui
This contains the presentation layer, MAUI and platform specific code. 

I have to mention that only the ResizeMAUI.Application.Maui project contains MAUI specific NuGet packages. For calculating the Page Layouts I needed to know some platform specific characteristics, like idiom (phone or table) and platform (iOS or not). By passing this data from the Applciation layer into the ViewModel layer, I can keep the latter free from platform specific, higher level NuGet packages.

Similarly, I didn't want to include Observability to my datamodel classes, as this is only useful in a MVVM scenario. In my own complete project I have an additional Services project that uses the Models to persist the data to the database. Any Observability on the models would be completely redundant here. The ObservableModels project is used to fill the gap for only those models that need it.


# Solution
There are three parts in the code that are important:

File: ResizeMAUI.Application.Maui/MainPage Function: SizeAllocated
This function is called when the page is created and when it is resized. Most importantly the width and height are the dimensions of the drawable area, without bars.
Unfortunately, there is a small peculiarity for IOS that has to be taken into account.

File: ResizeMAUI.Models/Factories/PageLayoutFactory Function: CreatePageLayouts
This function calculates the multiplier that is needed the resize the UI elements to their correct size

File: ResizeMAUI.ObservableModels/ObservablePageLayout
This class uses the PageLayout multiplier to convert to original dimension of the UI elements to their new dimensions
Setting the ObservablePageLayout to a new value triggers a screen refresh

# How it works

1. When the MainPage is built up, it calls SizeAllocated
2. SizeAllocated call MainViewModel.CreatePageLayouts
3. CreatePageLayout calculate the Multiplier and sets the ObservablePageLayout
4. The properties of the ObservablePageLayout are multiplied with the Multiplier and therefore showing the UI element in its desired size.
5. In case the screen can be resized, SizeAllocated gets called and the Multiplier is recalculated

In my own project, I gave the user the possibility to select another Page layout, with its own calculated Multiplier. Selecting another Page layout also triggers an UI refresh
