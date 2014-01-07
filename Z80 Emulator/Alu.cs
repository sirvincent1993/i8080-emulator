﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Word = System.Byte;
using DWord = System.UInt16;

namespace eZet.i8080.Emulator {
    public class Alu {

        private int tmp;
        public bool Carry { get; private set; }

        public Alu() {
        }

        public void reset() {
            Carry = false;
        }

        public Word add(params Word[] list) {
            tmp = 0;
            foreach (var val in list) {
                tmp += val;
            }
            checkCarry(Word.MinValue, Word.MaxValue);
            return (Word)tmp;
        }
        public DWord add(params DWord[]list) {
            tmp = 0;
            foreach (var val in list) {
                tmp += val;
            }
            checkCarry(DWord.MinValue, DWord.MaxValue);
            return (DWord)tmp;
        }

        public Word sub(params Word[] list) {
            tmp = list[0];
            foreach (var value in list.Skip(1)) {
                tmp -= value;
            }
            checkCarry(Word.MinValue, Word.MaxValue);
            return (Word)tmp; ;
        }


        public DWord sub(params DWord[] list) {
            tmp = list[0];
            foreach (var value in list.Skip(1)) {
                tmp -= value;
            }
            checkCarry(DWord.MinValue, DWord.MaxValue);
            return (DWord)tmp;
        }

        public Word shiftLeft(Word value, int count) {
            tmp = value << count;
            return (Word)tmp;
        }
        public Word shiftRight(Word value, int count) {
            tmp = value >> count;
            return (Word)tmp;
        }


        public Word rotateCarryLeft(Word value, int count, bool carry) {
            // TODO implement.
            throw new NotImplementedException("rotateCarryLeft");
        }

        public Word rotateCarryRight(Word value, int count, bool carry) {
            // TODO implement
            throw new NotImplementedException("rotateCarryRight");
        }

        public Word rotateLeft(Word value, int count) {
            return (Word)((value << count) | (value >> (8 - count)));
        }

        public Word rotateRight(Word value, int count) {
            return (Word)((value >> count) | (value << (8 - count)));
        }

        public Word and(params Word[] list) {
            tmp = list[0];
            foreach (var value in list.Skip(1)) {
                tmp &= value;
            }
            checkCarry(Word.MinValue, Word.MaxValue);
            return (Word)tmp;
        }

        public Word or(params Word[] list) {
            tmp = list[0];
            foreach (var value in list.Skip(1)) {
                tmp |= value;
            }
            checkCarry(Word.MinValue, Word.MaxValue);
            return (Word)tmp;
        }

        public Word xor(params Word[] list) {
            tmp = list[0];
            foreach (var value in list.Skip(1)) {
                tmp ^= value;
            }
            checkCarry(Word.MinValue, Word.MaxValue);
            return (Word)tmp;
        }


        private void checkCarry(int min, int max) {
            if (tmp < min || tmp > max) {
                Carry = true;
            } else {
                Carry = false;
            }
        }

       

   

    }
}
