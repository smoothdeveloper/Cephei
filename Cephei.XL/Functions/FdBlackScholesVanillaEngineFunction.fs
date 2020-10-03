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
module FdBlackScholesVanillaEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_FdBlackScholesVanillaEngine1", Description="Create a FdBlackScholesVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdBlackScholesVanillaEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="quantoHelper",Description = "Reference to quantoHelper")>] 
         quantoHelper : obj)
        ([<ExcelArgument(Name="tGrid",Description = "Reference to tGrid")>] 
         tGrid : obj)
        ([<ExcelArgument(Name="xGrid",Description = "Reference to xGrid")>] 
         xGrid : obj)
        ([<ExcelArgument(Name="dampingSteps",Description = "Reference to dampingSteps")>] 
         dampingSteps : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        ([<ExcelArgument(Name="localVol",Description = "Reference to localVol")>] 
         localVol : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "Reference to illegalLocalVolOverwrite")>] 
         illegalLocalVolOverwrite : obj)
        ([<ExcelArgument(Name="cashDividendModel",Description = "Reference to cashDividendModel")>] 
         cashDividendModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _quantoHelper = Helper.toDefault<FdmQuantoHelper> quantoHelper "quantoHelper" null
                let _tGrid = Helper.toDefault<int> tGrid "tGrid" 100
                let _xGrid = Helper.toDefault<int> xGrid "xGrid" 100
                let _dampingSteps = Helper.toDefault<int> dampingSteps "dampingSteps" 0
                let _schemeDesc = Helper.toDefault<FdmSchemeDesc> schemeDesc "schemeDesc" null
                let _localVol = Helper.toDefault<bool> localVol "localVol" false
                let _illegalLocalVolOverwrite = Helper.toNullable<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite"
                let _cashDividendModel = Helper.toDefault<FdBlackScholesVanillaEngine.CashDividendModel> cashDividendModel "cashDividendModel" FdBlackScholesVanillaEngine.CashDividendModel.Spot
                let builder () = withMnemonic mnemonic (Fun.FdBlackScholesVanillaEngine1 
                                                            _Process.cell 
                                                            _quantoHelper.cell 
                                                            _tGrid.cell 
                                                            _xGrid.cell 
                                                            _dampingSteps.cell 
                                                            _schemeDesc.cell 
                                                            _localVol.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                            _cashDividendModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdBlackScholesVanillaEngine>) l

                let source = Helper.sourceFold "Fun.FdBlackScholesVanillaEngine1" 
                                               [| _Process.source
                                               ;  _quantoHelper.source
                                               ;  _tGrid.source
                                               ;  _xGrid.source
                                               ;  _dampingSteps.source
                                               ;  _schemeDesc.source
                                               ;  _localVol.source
                                               ;  _illegalLocalVolOverwrite.source
                                               ;  _cashDividendModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _quantoHelper.cell
                                ;  _tGrid.cell
                                ;  _xGrid.cell
                                ;  _dampingSteps.cell
                                ;  _schemeDesc.cell
                                ;  _localVol.cell
                                ;  _illegalLocalVolOverwrite.cell
                                ;  _cashDividendModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdBlackScholesVanillaEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdBlackScholesVanillaEngine", Description="Create a FdBlackScholesVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdBlackScholesVanillaEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="tGrid",Description = "Reference to tGrid")>] 
         tGrid : obj)
        ([<ExcelArgument(Name="xGrid",Description = "Reference to xGrid")>] 
         xGrid : obj)
        ([<ExcelArgument(Name="dampingSteps",Description = "Reference to dampingSteps")>] 
         dampingSteps : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        ([<ExcelArgument(Name="localVol",Description = "Reference to localVol")>] 
         localVol : obj)
        ([<ExcelArgument(Name="illegalLocalVolOverwrite",Description = "Reference to illegalLocalVolOverwrite")>] 
         illegalLocalVolOverwrite : obj)
        ([<ExcelArgument(Name="cashDividendModel",Description = "Reference to cashDividendModel")>] 
         cashDividendModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _tGrid = Helper.toDefault<int> tGrid "tGrid" 100
                let _xGrid = Helper.toDefault<int> xGrid "xGrid" 100
                let _dampingSteps = Helper.toDefault<int> dampingSteps "dampingSteps" 0
                let _schemeDesc = Helper.toDefault<FdmSchemeDesc> schemeDesc "schemeDesc" null
                let _localVol = Helper.toDefault<bool> localVol "localVol" false
                let _illegalLocalVolOverwrite = Helper.toNullable<double> illegalLocalVolOverwrite "illegalLocalVolOverwrite"
                let _cashDividendModel = Helper.toDefault<FdBlackScholesVanillaEngine.CashDividendModel> cashDividendModel "cashDividendModel" FdBlackScholesVanillaEngine.CashDividendModel.Spot
                let builder () = withMnemonic mnemonic (Fun.FdBlackScholesVanillaEngine
                                                            _Process.cell 
                                                            _tGrid.cell 
                                                            _xGrid.cell 
                                                            _dampingSteps.cell 
                                                            _schemeDesc.cell 
                                                            _localVol.cell 
                                                            _illegalLocalVolOverwrite.cell 
                                                            _cashDividendModel.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdBlackScholesVanillaEngine>) l

                let source = Helper.sourceFold "Fun.FdBlackScholesVanillaEngine" 
                                               [| _Process.source
                                               ;  _tGrid.source
                                               ;  _xGrid.source
                                               ;  _dampingSteps.source
                                               ;  _schemeDesc.source
                                               ;  _localVol.source
                                               ;  _illegalLocalVolOverwrite.source
                                               ;  _cashDividendModel.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _tGrid.cell
                                ;  _xGrid.cell
                                ;  _dampingSteps.cell
                                ;  _schemeDesc.cell
                                ;  _localVol.cell
                                ;  _illegalLocalVolOverwrite.cell
                                ;  _cashDividendModel.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdBlackScholesVanillaEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdBlackScholesVanillaEngine_Range", Description="Create a range of FdBlackScholesVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdBlackScholesVanillaEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdBlackScholesVanillaEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdBlackScholesVanillaEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdBlackScholesVanillaEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdBlackScholesVanillaEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdBlackScholesVanillaEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"