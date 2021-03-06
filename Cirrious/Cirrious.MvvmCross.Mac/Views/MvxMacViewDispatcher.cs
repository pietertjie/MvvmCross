// <copyright file="MvxTouchViewDispatcher.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

using System;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Interfaces.Views;
using Cirrious.MvvmCross.Mac.Interfaces;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.Platform.Diagnostics;
using Cirrious.CrossCore;

namespace Cirrious.MvvmCross.Mac.Views
{
    public class MvxMacViewDispatcher 
        : MvxMacUIThreadDispatcher
        , IMvxViewDispatcher
    {
        private readonly IMvxMacViewPresenter _presenter;

        public MvxMacViewDispatcher(IMvxMacViewPresenter presenter)
        {
            _presenter = presenter;
        }

        public bool RequestNavigate(MvxViewModelRequest request)
        {
            Action action = () =>
                                {
                                    Mvx.TaggedTrace("MacNavigation", "Navigate requested");
                                    _presenter.Show(request);
                                };
            return RequestMainThreadAction(action);
        }
        
		public bool ChangePresentation(MvxPresentationHint hint)
        {
            Action action = () =>
                                {
                                    Mvx.TaggedTrace("MacNavigation", "Change presentation requested");
                                    _presenter.ChangePresentation(hint);
                                };
            return RequestMainThreadAction(action);
        }
    }
}