﻿(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module MixedLinearFritschButlandCubicFunction =

    (*
        ! \pre the \f$ x \f$ values must be sorted.
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xEnd",Description = "Reference to xEnd")>] 
         xEnd : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="behavior",Description = "Reference to behavior")>] 
         behavior : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xEnd = Helper.toCell<int> xEnd "xEnd" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _n = Helper.toCell<int> n "n" 
                let _behavior = Helper.toDefault<Behavior> behavior "behavior" Behavior.ShareRanges
                let builder () = withMnemonic mnemonic (Fun.MixedLinearFritschButlandCubic 
                                                            _xBegin.cell 
                                                            _xEnd.cell 
                                                            _yBegin.cell 
                                                            _n.cell 
                                                            _behavior.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MixedLinearFritschButlandCubic>) l

                let source = Helper.sourceFold "Fun.MixedLinearFritschButlandCubic" 
                                               [| _xBegin.source
                                               ;  _xEnd.source
                                               ;  _yBegin.source
                                               ;  _n.source
                                               ;  _behavior.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _xEnd.cell
                                ;  _yBegin.cell
                                ;  _n.cell
                                ;  _behavior.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MixedLinearFritschButlandCubic> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_derivative", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".Derivative") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_empty", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".Empty") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_primitive", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".Primitive") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_secondDerivative", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".SecondDerivative") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_update", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).Update
                                                       ) :> ICell
                let format (o : MixedLinearFritschButlandCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".Update") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_value1", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_value1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).Value1
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".Value1") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                ;  _x.cell
                                ;  _allowExtrapolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_value", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".Value") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_xMax", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".XMax") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_xMin", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".XMin") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        some extra functionality
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_allowsExtrapolation", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".AllowsExtrapolation") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_disableExtrapolation", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearFritschButlandCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".DisableExtrapolation") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_enableExtrapolation", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : MixedLinearFritschButlandCubic) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".EnableExtrapolation") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_extrapolate", Description="Create a MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MixedLinearFritschButlandCubic",Description = "Reference to MixedLinearFritschButlandCubic")>] 
         mixedlinearfritschbutlandcubic : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MixedLinearFritschButlandCubic = Helper.toCell<MixedLinearFritschButlandCubic> mixedlinearfritschbutlandcubic "MixedLinearFritschButlandCubic"  
                let builder () = withMnemonic mnemonic ((_MixedLinearFritschButlandCubic.cell :?> MixedLinearFritschButlandCubicModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MixedLinearFritschButlandCubic.source + ".Extrapolate") 
                                               [| _MixedLinearFritschButlandCubic.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MixedLinearFritschButlandCubic.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MixedLinearFritschButlandCubic_Range", Description="Create a range of MixedLinearFritschButlandCubic",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MixedLinearFritschButlandCubic_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MixedLinearFritschButlandCubic")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MixedLinearFritschButlandCubic> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MixedLinearFritschButlandCubic>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MixedLinearFritschButlandCubic>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MixedLinearFritschButlandCubic>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"