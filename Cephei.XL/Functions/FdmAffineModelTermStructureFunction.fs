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
module FdmAffineModelTermStructureFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        ([<ExcelArgument(Name="cal",Description = "Reference to cal")>] 
         cal : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="modelReferenceDate",Description = "Reference to modelReferenceDate")>] 
         modelReferenceDate : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _r = Helper.toCell<Vector> r "r" 
                let _cal = Helper.toCell<Calendar> cal "cal" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _modelReferenceDate = Helper.toCell<Date> modelReferenceDate "modelReferenceDate" 
                let _model = Helper.toCell<IAffineModel> model "model" 
                let builder () = withMnemonic mnemonic (Fun.FdmAffineModelTermStructure 
                                                            _r.cell 
                                                            _cal.cell 
                                                            _dayCounter.cell 
                                                            _referenceDate.cell 
                                                            _modelReferenceDate.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmAffineModelTermStructure>) l

                let source = Helper.sourceFold "Fun.FdmAffineModelTermStructure" 
                                               [| _r.source
                                               ;  _cal.source
                                               ;  _dayCounter.source
                                               ;  _referenceDate.source
                                               ;  _modelReferenceDate.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _r.cell
                                ;  _cal.cell
                                ;  _dayCounter.cell
                                ;  _referenceDate.cell
                                ;  _modelReferenceDate.cell
                                ;  _model.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_maxDate", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".MaxDate") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_setVariable", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_setVariable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _r = Helper.toCell<Vector> r "r" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).SetVariable
                                                            _r.cell 
                                                       ) :> ICell
                let format (o : FdmAffineModelTermStructure) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".SetVariable") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _r.cell
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
        ! The same day-counting rule used by the term structure should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_discount", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _t = Helper.toCell<double> t "t" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).Discount
                                                            _t.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".Discount") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _t.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _t.cell
                                ;  _extrapolate.cell
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
        These methods return the discount factor from a given date or time to the reference date.  In the latter case, the time is calculated as a fraction of year from the reference date.
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_discount1", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_discount1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _d = Helper.toCell<Date> d "d" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).Discount1
                                                            _d.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".Discount1") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _d.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _d.cell
                                ;  _extrapolate.cell
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
        ! The resulting interest rate has the required day-counting rule. \warning dates are not adjusted for holidays
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_forwardRate", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_forwardRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).ForwardRate
                                                            _d.cell 
                                                            _p.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".ForwardRate") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the required day-counting rule.
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_forwardRate1", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_forwardRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).ForwardRate1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".ForwardRate1") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed times t1 and t2.
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_forwardRate2", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_forwardRate2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="t1",Description = "Reference to t1")>] 
         t1 : obj)
        ([<ExcelArgument(Name="t2",Description = "Reference to t2")>] 
         t2 : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _t1 = Helper.toCell<double> t1 "t1" 
                let _t2 = Helper.toCell<double> t2 "t2" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).ForwardRate2
                                                            _t1.cell 
                                                            _t2.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".ForwardRate2") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _t1.source
                                               ;  _t2.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _t1.cell
                                ;  _t2.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_jumpDates", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_jumpDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).JumpDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".JumpDates") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_jumpTimes", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_jumpTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).JumpTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".JumpTimes") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_update", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).Update
                                                       ) :> ICell
                let format (o : FdmAffineModelTermStructure) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".Update") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
        ! The resulting interest rate has the required daycounting rule.
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_zeroRate1", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_zeroRate1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _d = Helper.toCell<Date> d "d" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).ZeroRate1
                                                            _d.cell 
                                                            _dayCounter.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".ZeroRate1") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _d.source
                                               ;  _dayCounter.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _d.cell
                                ;  _dayCounter.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The resulting interest rate has the same day-counting rule used by the term structure. The same rule should be used for calculating the passed time t.
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_zeroRate", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_zeroRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _t = Helper.toCell<double> t "t" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).ZeroRate
                                                            _t.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterestRate>) l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".ZeroRate") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _t.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _t.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _extrapolate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_calendar", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".Calendar") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_dayCounter", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".DayCounter") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmAffineModelTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_maxTime", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".MaxTime") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_referenceDate", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".ReferenceDate") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_settlementDays", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".SettlementDays") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_timeFromReference", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".TimeFromReference") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_allowsExtrapolation", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".AllowsExtrapolation") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_disableExtrapolation", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FdmAffineModelTermStructure) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".DisableExtrapolation") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_enableExtrapolation", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : FdmAffineModelTermStructure) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".EnableExtrapolation") 
                                               [| _FdmAffineModelTermStructure.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_extrapolate", Description="Create a FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmAffineModelTermStructure",Description = "Reference to FdmAffineModelTermStructure")>] 
         fdmaffinemodeltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmAffineModelTermStructure = Helper.toCell<FdmAffineModelTermStructure> fdmaffinemodeltermstructure "FdmAffineModelTermStructure"  
                let builder () = withMnemonic mnemonic ((_FdmAffineModelTermStructure.cell :?> FdmAffineModelTermStructureModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmAffineModelTermStructure.source + ".Extrapolate") 
                                               [| _FdmAffineModelTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmAffineModelTermStructure.cell
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
    [<ExcelFunction(Name="_FdmAffineModelTermStructure_Range", Description="Create a range of FdmAffineModelTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmAffineModelTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmAffineModelTermStructure")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmAffineModelTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmAffineModelTermStructure>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmAffineModelTermStructure>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmAffineModelTermStructure>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"