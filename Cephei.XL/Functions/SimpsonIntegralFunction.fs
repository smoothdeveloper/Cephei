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
  the correctness of the result is tested by checking it against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module SimpsonIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SimpsonIntegral", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIterations",Description = "Reference to maxIterations")>] 
         maxIterations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" 
                let builder () = withMnemonic mnemonic (Fun.SimpsonIntegral 
                                                            _accuracy.cell 
                                                            _maxIterations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SimpsonIntegral>) l

                let source = Helper.sourceFold "Fun.SimpsonIntegral" 
                                               [| _accuracy.source
                                               ;  _maxIterations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _accuracy.cell
                                ;  _maxIterations.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SimpsonIntegral> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_SimpsonIntegral_absoluteAccuracy", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_absoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).AbsoluteAccuracy
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".AbsoluteAccuracy") 
                                               [| _SimpsonIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_absoluteError", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_absoluteError
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).AbsoluteError
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".AbsoluteError") 
                                               [| _SimpsonIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_integrationSuccess", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_integrationSuccess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).IntegrationSuccess
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".IntegrationSuccess") 
                                               [| _SimpsonIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_maxEvaluations", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_maxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).MaxEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".MaxEvaluations") 
                                               [| _SimpsonIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_numberOfEvaluations", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".NumberOfEvaluations") 
                                               [| _SimpsonIntegral.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
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
        Modifiers
    *)
    [<ExcelFunction(Name="_SimpsonIntegral_setAbsoluteAccuracy", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_setAbsoluteAccuracy
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).SetAbsoluteAccuracy
                                                            _accuracy.cell 
                                                       ) :> ICell
                let format (o : SimpsonIntegral) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".SetAbsoluteAccuracy") 
                                               [| _SimpsonIntegral.source
                                               ;  _accuracy.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
                                ;  _accuracy.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_setMaxEvaluations", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_setMaxEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).SetMaxEvaluations
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : SimpsonIntegral) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".SetMaxEvaluations") 
                                               [| _SimpsonIntegral.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_value", Description="Create a SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SimpsonIntegral",Description = "Reference to SimpsonIntegral")>] 
         simpsonintegral : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SimpsonIntegral = Helper.toCell<SimpsonIntegral> simpsonintegral "SimpsonIntegral"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder () = withMnemonic mnemonic ((_SimpsonIntegral.cell :?> SimpsonIntegralModel).Value
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SimpsonIntegral.source + ".Value") 
                                               [| _SimpsonIntegral.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SimpsonIntegral.cell
                                ;  _f.cell
                                ;  _a.cell
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
    [<ExcelFunction(Name="_SimpsonIntegral_Range", Description="Create a range of SimpsonIntegral",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SimpsonIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SimpsonIntegral")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SimpsonIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SimpsonIntegral>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SimpsonIntegral>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SimpsonIntegral>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
