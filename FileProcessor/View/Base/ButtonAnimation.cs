using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
namespace FileProcessor.View.Base
{
    /// <summary>
    /// Uses animation to make a button visible or invisible. Changes the width property in each of the methods, creating the effect of a slide in or slide away button.
    /// </summary>
    /// <summary>
    ///     Programmer       : R. Dookkoo.
    ///     Modified Date    : 02 June 2017.
    /// </summary>
    /// <remarks>
    ///     Usage: Used in the Sample application, availabe to use in .Net Framework applications.
    /// </remarks>
    /// <example>
    /// C#
    /// <code>
    ///    ButtonAnimation.ButtonToAnimate = Button2;
    ///    ButtonAnimation.MakeButtonSlideAway();
    /// </code>
    /// VB
    /// <code>
    ///    ButtonAnimation.ButtonToAnimate = Button1;
    ///    ButtonAnimation.MakeButtonSlideAway();
    /// </code>
    /// </example>
    public class ButtonAnimation
    {
        #region Public Properties

        /// <summary>
        /// Sets the button that the animation would be performed on
        /// </summary>
        public static Button ButtonToAnimate { get; set; }

        #endregion

        #region  Public Methods

        /// <summary>
        /// Uses animation to reduce the width of a button, thereby making the button slide out
        /// </summary>
        public static void MakeButtonSlideAway()
        {
            var buttonBusyAnimation = new DoubleAnimation
            { From = ButtonToAnimate.Width, To = 0, Duration = TimeSpan.FromSeconds(.3) };

            ButtonToAnimate.BeginAnimation(FrameworkElement.WidthProperty, buttonBusyAnimation);
        }

        /// <summary>
        /// Uses animation to increase the width of a button, thereby making the button slide in.
        /// </summary>
        public static void MakeButtonSlideBack()
        {
            var buttonBusyAnimation = new DoubleAnimation
            { From = 0, To = ButtonToAnimate.Width, Duration = TimeSpan.FromSeconds(.3) };

            ButtonToAnimate.BeginAnimation(FrameworkElement.WidthProperty, buttonBusyAnimation);
        }

        #endregion
    }
}