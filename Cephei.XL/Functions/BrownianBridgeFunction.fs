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
  This class generates normalized (i.e., unit-variance) paths as sequences of variations. In order to obtain the actual path of the underlying, the returned variations must be multiplied by the integrated variance (including time) over the corresponding time step.  mcarlo
  </summary> *)
[<AutoSerializable(true)>]
module BrownianBridgeFunction =

    (*
        ! generic times
    *)
    [<ExcelFunction(Name="_BrownianBridge", Description="Create a BrownianBridge",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BrownianBridge_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeGrid",Description = "Reference to timeGrid")>] 
         timeGrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let builder () = withMnemonic mnemonic (Fun.BrownianBridge 
                                                            _timeGrid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BrownianBridge>) l

                let source = Helper.sourceFold "Fun.BrownianBridge" 
                                               [| _timeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _timeGrid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BrownianBridge> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \note the starting time of the path is assumed to be 0 and must not be included
    *)
    [<ExcelFunction(Name="_BrownianBridge1", Description="Create a BrownianBridge",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BrownianBridge_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="times",Description = "Reference to times")>] 
         times : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _times = Helper.toCell<Generic.List<double>> times "times" 
                let builder () = withMnemonic mnemonic (Fun.BrownianBridge1 
                                                            _times.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BrownianBridge>) l

                let source = Helper.sourceFold "Fun.BrownianBridge1" 
                                               [| _times.source
                                               |]
                let hash = Helper.hashFold 
                                [| _times.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BrownianBridge> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! unit-time path
    *)
    [<ExcelFunction(Name="_BrownianBridge2", Description="Create a BrownianBridge",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BrownianBridge_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _steps = Helper.toCell<int> steps "steps" 
                let builder () = withMnemonic mnemonic (Fun.BrownianBridge2 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BrownianBridge>) l

                let source = Helper.sourceFold "Fun.BrownianBridge2" 
                                               [| _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _steps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BrownianBridge> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BrownianBridge_size", Description="Create a BrownianBridge",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BrownianBridge_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BrownianBridge",Description = "Reference to BrownianBridge")>] 
         brownianbridge : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BrownianBridge = Helper.toCell<BrownianBridge> brownianbridge "BrownianBridge"  
                let builder () = withMnemonic mnemonic ((_BrownianBridge.cell :?> BrownianBridgeModel).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BrownianBridge.source + ".Size") 
                                               [| _BrownianBridge.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BrownianBridge.cell
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
    [<ExcelFunction(Name="_BrownianBridge_times", Description="Create a BrownianBridge",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BrownianBridge_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BrownianBridge",Description = "Reference to BrownianBridge")>] 
         brownianbridge : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BrownianBridge = Helper.toCell<BrownianBridge> brownianbridge "BrownianBridge"  
                let builder () = withMnemonic mnemonic ((_BrownianBridge.cell :?> BrownianBridgeModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_BrownianBridge.source + ".Times") 
                                               [| _BrownianBridge.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BrownianBridge.cell
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
        Brownian-bridge constructor
    *)
    [<ExcelFunction(Name="_BrownianBridge_transform", Description="Create a BrownianBridge",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BrownianBridge_transform
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BrownianBridge",Description = "Reference to BrownianBridge")>] 
         brownianbridge : obj)
        ([<ExcelArgument(Name="Begin",Description = "Reference to Begin")>] 
         Begin : obj)
        ([<ExcelArgument(Name="output",Description = "Reference to output")>] 
         output : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BrownianBridge = Helper.toCell<BrownianBridge> brownianbridge "BrownianBridge"  
                let _Begin = Helper.toCell<Generic.List<double>> Begin "Begin" 
                let _output = Helper.toCell<Generic.List<double>> output "output" 
                let builder () = withMnemonic mnemonic ((_BrownianBridge.cell :?> BrownianBridgeModel).Transform
                                                            _Begin.cell 
                                                            _output.cell 
                                                       ) :> ICell
                let format (o : BrownianBridge) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BrownianBridge.source + ".Transform") 
                                               [| _BrownianBridge.source
                                               ;  _Begin.source
                                               ;  _output.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BrownianBridge.cell
                                ;  _Begin.cell
                                ;  _output.cell
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
    [<ExcelFunction(Name="_BrownianBridge_Range", Description="Create a range of BrownianBridge",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BrownianBridge_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BrownianBridge")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BrownianBridge> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BrownianBridge>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BrownianBridge>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BrownianBridge>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
