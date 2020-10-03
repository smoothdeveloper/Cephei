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
module DiscretizedDoubleBarrierOptionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_checkBarrier", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_checkBarrier
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        ([<ExcelArgument(Name="optvalues",Description = "Reference to optvalues")>] 
         optvalues : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let _optvalues = Helper.toCell<Vector> optvalues "optvalues" 
                let _grid = Helper.toDefault<Vector> grid "grid" null
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).CheckBarrier
                                                            _optvalues.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".CheckBarrier") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               ;  _optvalues.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                ;  _optvalues.cell
                                ;  _grid.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="args",Description = "Reference to args")>] 
         args : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _args = Helper.toCell<DoubleBarrierOption.Arguments> args "args" 
                let _Process = Helper.toCell<StochasticProcess> Process "Process" 
                let _grid = Helper.toDefault<TimeGrid> grid "grid" null
                let builder () = withMnemonic mnemonic (Fun.DiscretizedDoubleBarrierOption 
                                                            _args.cell 
                                                            _Process.cell 
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DiscretizedDoubleBarrierOption>) l

                let source = Helper.sourceFold "Fun.DiscretizedDoubleBarrierOption" 
                                               [| _args.source
                                               ;  _Process.source
                                               ;  _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _args.cell
                                ;  _Process.cell
                                ;  _grid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_mandatoryTimes", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".MandatoryTimes") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_reset", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let _size = Helper.toCell<int> size "size" 
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".Reset") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               ;  _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_vanilla", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_vanilla
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).Vanilla
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".Vanilla") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! This method performs both pre- and post-adjustment
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_adjustValues", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".AdjustValues") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
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
        High-level interface  Users of discretized assets should use these methods in order to initialize, evolve and take the present value of the assets.  They call the corresponding methods in the Lattice interface, to which we refer for documentation.
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_initialize", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        ([<ExcelArgument(Name="Method",Description = "Reference to Method")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".Initialize") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               ;  _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                ;  _Method.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_method", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".METHOD") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_partialRollback", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".PartialRollback") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                ;  _To.cell
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
        ! This method will be invoked after rollback and after any other asset had their chance to look at the values. For instance, payments happening at the present time (and therefore not included in an option to be exercised at this time) will be added here.  This method is not virtual; derived classes must override the protected postAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_postAdjustValues", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".PostAdjustValues") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
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
        ! This method will be invoked after rollback and before any other asset (i.e., an option on this one) has any chance to look at the values. For instance, payments happening at times already spanned by the rollback will be added here.  This method is not virtual; derived classes must override the protected preAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_preAdjustValues", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".PreAdjustValues") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_presentValue", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".PresentValue") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_rollback", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".Rollback") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                ;  _To.cell
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
        safe version of QL double* time()
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_setTime", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".SetTime") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                ;  _t.cell
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
        safe version of QL Vector* values()
    *)
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_setValues", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDoubleBarrierOption) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".SetValues") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_time", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".Time") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
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
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_values", Description="Create a DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDoubleBarrierOption",Description = "Reference to DiscretizedDoubleBarrierOption")>] 
         discretizeddoublebarrieroption : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDoubleBarrierOption = Helper.toCell<DiscretizedDoubleBarrierOption> discretizeddoublebarrieroption "DiscretizedDoubleBarrierOption"  
                let builder () = withMnemonic mnemonic ((_DiscretizedDoubleBarrierOption.cell :?> DiscretizedDoubleBarrierOptionModel).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_DiscretizedDoubleBarrierOption.source + ".Values") 
                                               [| _DiscretizedDoubleBarrierOption.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDoubleBarrierOption.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDoubleBarrierOption> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedDoubleBarrierOption_Range", Description="Create a range of DiscretizedDoubleBarrierOption",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscretizedDoubleBarrierOption_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DiscretizedDoubleBarrierOption")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedDoubleBarrierOption> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedDoubleBarrierOption>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedDoubleBarrierOption>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DiscretizedDoubleBarrierOption>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"