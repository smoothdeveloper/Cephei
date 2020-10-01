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
module FdmSolverDescFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmSolverDesc_bcSet", Description="Create a FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_bcSet
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSolverDesc",Description = "Reference to FdmSolverDesc")>] 
         fdmsolverdesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSolverDesc = Helper.toCell<FdmSolverDesc> fdmsolverdesc "FdmSolverDesc"  
                let builder () = withMnemonic mnemonic ((_FdmSolverDesc.cell :?> FdmSolverDescModel).BcSet
                                                       ) :> ICell
                let format (o : FdmBoundaryConditionSet) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmSolverDesc.source + ".BcSet") 
                                               [| _FdmSolverDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSolverDesc.cell
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
    [<ExcelFunction(Name="_FdmSolverDesc_calculator", Description="Create a FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_calculator
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSolverDesc",Description = "Reference to FdmSolverDesc")>] 
         fdmsolverdesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSolverDesc = Helper.toCell<FdmSolverDesc> fdmsolverdesc "FdmSolverDesc"  
                let builder () = withMnemonic mnemonic ((_FdmSolverDesc.cell :?> FdmSolverDescModel).Calculator
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmInnerValueCalculator>) l

                let source = Helper.sourceFold (_FdmSolverDesc.source + ".Calculator") 
                                               [| _FdmSolverDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSolverDesc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSolverDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSolverDesc_condition", Description="Create a FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_condition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSolverDesc",Description = "Reference to FdmSolverDesc")>] 
         fdmsolverdesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSolverDesc = Helper.toCell<FdmSolverDesc> fdmsolverdesc "FdmSolverDesc"  
                let builder () = withMnemonic mnemonic ((_FdmSolverDesc.cell :?> FdmSolverDescModel).Condition
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmStepConditionComposite>) l

                let source = Helper.sourceFold (_FdmSolverDesc.source + ".Condition") 
                                               [| _FdmSolverDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSolverDesc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSolverDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSolverDesc_dampingSteps", Description="Create a FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_dampingSteps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSolverDesc",Description = "Reference to FdmSolverDesc")>] 
         fdmsolverdesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSolverDesc = Helper.toCell<FdmSolverDesc> fdmsolverdesc "FdmSolverDesc"  
                let builder () = withMnemonic mnemonic ((_FdmSolverDesc.cell :?> FdmSolverDescModel).DampingSteps
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmSolverDesc.source + ".DampingSteps") 
                                               [| _FdmSolverDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSolverDesc.cell
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
    [<ExcelFunction(Name="_FdmSolverDesc_maturity", Description="Create a FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_maturity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSolverDesc",Description = "Reference to FdmSolverDesc")>] 
         fdmsolverdesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSolverDesc = Helper.toCell<FdmSolverDesc> fdmsolverdesc "FdmSolverDesc"  
                let builder () = withMnemonic mnemonic ((_FdmSolverDesc.cell :?> FdmSolverDescModel).Maturity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmSolverDesc.source + ".Maturity") 
                                               [| _FdmSolverDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSolverDesc.cell
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
    [<ExcelFunction(Name="_FdmSolverDesc_mesher", Description="Create a FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_mesher
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSolverDesc",Description = "Reference to FdmSolverDesc")>] 
         fdmsolverdesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSolverDesc = Helper.toCell<FdmSolverDesc> fdmsolverdesc "FdmSolverDesc"  
                let builder () = withMnemonic mnemonic ((_FdmSolverDesc.cell :?> FdmSolverDescModel).Mesher
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesher>) l

                let source = Helper.sourceFold (_FdmSolverDesc.source + ".Mesher") 
                                               [| _FdmSolverDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSolverDesc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSolverDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSolverDesc_timeSteps", Description="Create a FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_timeSteps
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSolverDesc",Description = "Reference to FdmSolverDesc")>] 
         fdmsolverdesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSolverDesc = Helper.toCell<FdmSolverDesc> fdmsolverdesc "FdmSolverDesc"  
                let builder () = withMnemonic mnemonic ((_FdmSolverDesc.cell :?> FdmSolverDescModel).TimeSteps
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmSolverDesc.source + ".TimeSteps") 
                                               [| _FdmSolverDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSolverDesc.cell
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
    [<ExcelFunction(Name="_FdmSolverDesc_Range", Description="Create a range of FdmSolverDesc",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmSolverDesc_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmSolverDesc")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmSolverDesc> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmSolverDesc>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmSolverDesc>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmSolverDesc>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
