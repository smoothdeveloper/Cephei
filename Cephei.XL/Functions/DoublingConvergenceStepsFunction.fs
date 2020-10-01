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
module DoublingConvergenceStepsFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DoublingConvergenceSteps_initialSamples", Description="Create a DoublingConvergenceSteps",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DoublingConvergenceSteps_initialSamples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoublingConvergenceSteps",Description = "Reference to DoublingConvergenceSteps")>] 
         doublingconvergencesteps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoublingConvergenceSteps = Helper.toCell<DoublingConvergenceSteps> doublingconvergencesteps "DoublingConvergenceSteps"  
                let builder () = withMnemonic mnemonic ((_DoublingConvergenceSteps.cell :?> DoublingConvergenceStepsModel).InitialSamples
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DoublingConvergenceSteps.source + ".InitialSamples") 
                                               [| _DoublingConvergenceSteps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DoublingConvergenceSteps.cell
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
    [<ExcelFunction(Name="_DoublingConvergenceSteps_nextSamples", Description="Create a DoublingConvergenceSteps",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DoublingConvergenceSteps_nextSamples
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DoublingConvergenceSteps",Description = "Reference to DoublingConvergenceSteps")>] 
         doublingconvergencesteps : obj)
        ([<ExcelArgument(Name="current",Description = "Reference to current")>] 
         current : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DoublingConvergenceSteps = Helper.toCell<DoublingConvergenceSteps> doublingconvergencesteps "DoublingConvergenceSteps"  
                let _current = Helper.toCell<int> current "current" 
                let builder () = withMnemonic mnemonic ((_DoublingConvergenceSteps.cell :?> DoublingConvergenceStepsModel).NextSamples
                                                            _current.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DoublingConvergenceSteps.source + ".NextSamples") 
                                               [| _DoublingConvergenceSteps.source
                                               ;  _current.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DoublingConvergenceSteps.cell
                                ;  _current.cell
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
    [<ExcelFunction(Name="_DoublingConvergenceSteps_Range", Description="Create a range of DoublingConvergenceSteps",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DoublingConvergenceSteps_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DoublingConvergenceSteps")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DoublingConvergenceSteps> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DoublingConvergenceSteps>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DoublingConvergenceSteps>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DoublingConvergenceSteps>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
