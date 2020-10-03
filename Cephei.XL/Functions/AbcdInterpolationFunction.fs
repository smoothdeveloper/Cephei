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
  interpolations
  </summary> *)
[<AutoSerializable(true)>]
module AbcdInterpolationFunction =

    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_AbcdInterpolation_a", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_a
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).A
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".A") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
        ! Constructor
    *)
    [<ExcelFunction(Name="_AbcdInterpolation", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="aIsFixed",Description = "Reference to aIsFixed")>] 
         aIsFixed : obj)
        ([<ExcelArgument(Name="bIsFixed",Description = "Reference to bIsFixed")>] 
         bIsFixed : obj)
        ([<ExcelArgument(Name="cIsFixed",Description = "Reference to cIsFixed")>] 
         cIsFixed : obj)
        ([<ExcelArgument(Name="dIsFixed",Description = "Reference to dIsFixed")>] 
         dIsFixed : obj)
        ([<ExcelArgument(Name="vegaWeighted",Description = "Reference to vegaWeighted")>] 
         vegaWeighted : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        ([<ExcelArgument(Name="optMethod",Description = "Reference to optMethod")>] 
         optMethod : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _a = Helper.toDefault<double> a "a" -0.06
                let _b = Helper.toDefault<double> b "b" 0.17
                let _c = Helper.toDefault<double> c "c" 0.54
                let _d = Helper.toDefault<double> d "d" 0.17
                let _aIsFixed = Helper.toDefault<bool> aIsFixed "aIsFixed" false
                let _bIsFixed = Helper.toDefault<bool> bIsFixed "bIsFixed" false
                let _cIsFixed = Helper.toDefault<bool> cIsFixed "cIsFixed" false
                let _dIsFixed = Helper.toDefault<bool> dIsFixed "dIsFixed" false
                let _vegaWeighted = Helper.toDefault<bool> vegaWeighted "vegaWeighted" false
                let _endCriteria = Helper.toDefault<EndCriteria> endCriteria "endCriteria" null
                let _optMethod = Helper.toDefault<OptimizationMethod> optMethod "optMethod" null
                let builder () = withMnemonic mnemonic (Fun.AbcdInterpolation 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                            _aIsFixed.cell 
                                                            _bIsFixed.cell 
                                                            _cIsFixed.cell 
                                                            _dIsFixed.cell 
                                                            _vegaWeighted.cell 
                                                            _endCriteria.cell 
                                                            _optMethod.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdInterpolation>) l

                let source = Helper.sourceFold "Fun.AbcdInterpolation" 
                                               [| _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               ;  _aIsFixed.source
                                               ;  _bIsFixed.source
                                               ;  _cIsFixed.source
                                               ;  _dIsFixed.source
                                               ;  _vegaWeighted.source
                                               ;  _endCriteria.source
                                               ;  _optMethod.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                ;  _aIsFixed.cell
                                ;  _bIsFixed.cell
                                ;  _cIsFixed.cell
                                ;  _dIsFixed.cell
                                ;  _vegaWeighted.cell
                                ;  _endCriteria.cell
                                ;  _optMethod.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdInterpolation> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdInterpolation_b", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_b
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).B
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".B") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_c", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_c
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).C
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".C") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_d", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_d
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).D
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".D") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_endCriteria", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_endCriteria
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).EndCriteria
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".EndCriteria") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_k", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_k
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _t = Helper.toCell<double> t "t" 
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).K
                                                            _t.cell 
                                                            _xBegin.cell 
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".K") 
                                               [| _AbcdInterpolation.source
                                               ;  _t.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
                                ;  _t.cell
                                ;  _xBegin.cell
                                ;  _size.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_k1", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_k1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).K1
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".K1") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdInterpolation_maxError", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_maxError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).MaxError
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".MaxError") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_rmsError", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_rmsError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).RmsError
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".RmsError") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_derivative", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_derivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).Derivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".Derivative") 
                                               [| _AbcdInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_empty", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".Empty") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_primitive", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).Primitive
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".Primitive") 
                                               [| _AbcdInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_secondDerivative", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_secondDerivative
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).SecondDerivative
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".SecondDerivative") 
                                               [| _AbcdInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_update", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).Update
                                                       ) :> ICell
                let format (o : AbcdInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".Update") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    (*!!
    [<ExcelFunction(Name="_AbcdInterpolation_value", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="allowExtrapolation",Description = "Reference to allowExtrapolation")>] 
         allowExtrapolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let _allowExtrapolation = Helper.toCell<bool> allowExtrapolation "allowExtrapolation" 
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).Value
                                                            _x.cell 
                                                            _allowExtrapolation.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".Value") 
                                               [| _AbcdInterpolation.source
                                               ;  _x.source
                                               ;  _allowExtrapolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
            "<WIZ>" *)
    (*
        main method to derive an interpolated point
    *)
    [<ExcelFunction(Name="_AbcdInterpolation_value", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".Value") 
                                               [| _AbcdInterpolation.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_xMax", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_xMax
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).XMax
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".XMax") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_xMin", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_xMin
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).XMin
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".XMin") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_allowsExtrapolation", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".AllowsExtrapolation") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_disableExtrapolation", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _b = Helper.toCell<bool> b "b"
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : AbcdInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".DisableExtrapolation") 
                                               [| _AbcdInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_enableExtrapolation", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let _b = Helper.toCell<bool> b "b"
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : AbcdInterpolation) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".EnableExtrapolation") 
                                               [| _AbcdInterpolation.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_extrapolate", Description="Create a AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdInterpolation",Description = "Reference to AbcdInterpolation")>] 
         abcdinterpolation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdInterpolation = Helper.toCell<AbcdInterpolation> abcdinterpolation "AbcdInterpolation"  
                let builder () = withMnemonic mnemonic ((_AbcdInterpolation.cell :?> AbcdInterpolationModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdInterpolation.source + ".Extrapolate") 
                                               [| _AbcdInterpolation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdInterpolation.cell
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
    [<ExcelFunction(Name="_AbcdInterpolation_Range", Description="Create a range of AbcdInterpolation",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdInterpolation_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AbcdInterpolation")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AbcdInterpolation> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AbcdInterpolation>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AbcdInterpolation>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AbcdInterpolation>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
