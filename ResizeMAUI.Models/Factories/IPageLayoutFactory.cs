﻿namespace ResizeMAUI.Models.Factories
{
    public interface IPageLayoutFactory
    {
        List<PageLayout> CreatePageLayouts(double width, double height, byte idiom, Thickness safeArea);
    }
}
