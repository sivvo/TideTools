#include <stdio.h> 
#include <iostream>
#include <tchar.h>

void	chomp(char *str); 
void	makeitem(char **item, char **head); 
int		lookup(char **header, char *name); 
int		calc_hash (const char *string); 
void	freearray(char **array); 
char	**septoarray(char *str, char sep);

int gl_book_pos, 
	gl_charm_pos, 
	gl_bag_pos, 
	gl_id_pos, 
	gl_name_pos, 
	gl_hp_pos, 
	gl_mana_pos, 
	gl_ac_pos, 
	gl_light_pos, 
	gl_icon_pos, 
	gl_price_pos, 
	gl_size_pos, 
	gl_weight_pos, 
	gl_booktype_pos, 
	gl_bagslots_pos,
	gl_bagwr_pos; 


int _tmain(int argc, _TCHAR* argv[])
{ 
   FILE *fp; 
   char **head, **item; 
   char buff[4096]; 

   fp = fopen("items.txt", "rt"); 

   if(!fp) { 
      printf("faild to open %s\n", "items.txt"); 
      return 1; 
   } 

   fgets(buff, 4096, fp); 
    
   chomp(buff); 
   head = septoarray(buff, '|'); 

   gl_book_pos = lookup(head, "book"); 
   gl_charm_pos = lookup(head, "charmfileid"); 
   gl_bag_pos = lookup(head, "bagtype"); 
   gl_id_pos = lookup(head, "id"); 
   gl_name_pos = lookup(head, "name"); 
   gl_hp_pos = lookup(head, "hp"); 
   gl_mana_pos = lookup(head, "mana"); 
   gl_ac_pos = lookup(head, "ac"); 
   gl_light_pos = lookup(head, "light"); 
   gl_icon_pos = lookup(head, "icon"); 
   gl_price_pos = lookup(head, "price"); 
   gl_size_pos = lookup(head, "size"); 
   gl_weight_pos = lookup(head, "weight"); 
   gl_booktype_pos = lookup(head, "booktype"); 
   gl_bagslots_pos = lookup(head, "bagslots"); 
   gl_bagwr_pos = lookup(head, "bagwr"); 

   while(!feof(fp)) { 
      fgets(buff, 4096, fp); 
      if(feof(fp)) break; 
      chomp(buff); 
      item = septoarray(buff, '|'); 
      makeitem(item, head); 
      freearray(item); 
   } 
   freearray(head); 

   fclose(fp); 

   return 0;
} 

void makeitem(char **item, char **head) 
{ 
   char name[1024]; 
   char hashstr[2048]; 
   int book, charm, bag, id, hp, mana, ac, light, icon, price, size, weight, booktype, bagslots, bagwr; 
   char *tmp; 
   int isbook = 0, ischarm = 0, isbag = 0; 
   int hash; 

   tmp = item[gl_book_pos];if(tmp) {isbook = atoi(tmp);} 
   tmp = item[gl_charm_pos]; if(tmp) {ischarm = atoi(tmp);} 
   tmp = item[gl_bag_pos]; if(tmp) {isbag = atoi(tmp);} 
   tmp = item[gl_id_pos];if(tmp) {id = atoi(tmp);} 
   tmp = item[gl_name_pos];if(tmp) {sprintf(name,tmp);} 
   tmp = item[gl_hp_pos];if(tmp) {hp = atoi(tmp);} 
   tmp = item[gl_mana_pos];if(tmp) {mana = atoi(tmp);} 
   tmp = item[gl_ac_pos];if(tmp) {ac = atoi(tmp);} 
   tmp = item[gl_light_pos];if(tmp) {light = atoi(tmp);} 
   tmp = item[gl_icon_pos];if(tmp) {icon = atoi(tmp);} 
   tmp = item[gl_price_pos];if(tmp) {price = atoi(tmp);} 
   tmp = item[gl_size_pos];if(tmp) {size = atoi(tmp);} 
   tmp = item[gl_weight_pos];if(tmp) {weight = atoi(tmp);} 
   tmp = item[gl_booktype_pos];if(tmp) {booktype = atoi(tmp);} 
   tmp = item[gl_bagslots_pos];if(tmp) {bagslots = atoi(tmp);} 
   tmp = item[gl_bagwr_pos];if(tmp) {bagwr = atoi(tmp);} 

   if(ischarm) { 
      sprintf(hashstr, "%d%s%s%d %d %d %d %d", id, name, "-1-1-1-1-1", light, icon, price, size, weight); 
      //printf("Charm: %s\n", name); 
   } else if(isbook) { 
      sprintf(hashstr, "%d%s%d%d", id, name, weight, booktype); 
      //printf("Book: %s\n", name); 
   } else if(isbag) { 
      sprintf(hashstr, "%d%s%d%d%d%d", id, name, bagslots, bagwr, price, weight); 
      //printf("Bag: %s\n", name); 
   } else { 
      sprintf(hashstr, "%d%s%s%d %d %d %d %d %d %d %d", id, name, "-1-1-1-1-1", hp, mana, ac, light, icon, price, size, weight); 
   } 

   hash = calc_hash(hashstr); 

   printf("%07d-00001-00001-00001-00001-00001%08X%s\n", id,hash,name); 
} 
int lookup(char **header, char *name) 
{ 
    int d; 

    for(d = 0; header[d] != NULL; d++) { 
        if(!strcmp(header[d], name)) return d; 
    } 
   return -1; 
} 
void chomp(char *str) 
{ 
   while(*str) { 
      if(*str == '\n' || *str == '\r') *str = '\0'; 
      str++; 
   } 
} 

int calc_hash (const char *string) 
{ 
    register hash = 0; 

    while (*string != '\0') 
    { 
        register c = toupper(*string); 

         hash *= 0x1f; 
         hash += (int)c; 

        string++; 
    } 

    return hash; 
} 

void freearray(char **array) 
{ 
   int d; 
    
   for(d = 0; array[d] != NULL; d++) { 
      free(array[d]); 
   } 
   free(array); 
} 

char **septoarray(char *str, char sep) 
{ 
   char **array; 
   char *c; 
   char *p; 
   int count = 0; 
    
   // calc the sep 
    
   c = str; 
   while(c) { 
      c = strchr(c, sep); 
      if(c) { 
         count++; 
         c++; 
      } 
   } 
    
   // make the array 
   array = (char **)malloc((count+2) * sizeof(char *)); 
   if(!array) return NULL; 
    
   count = 0; 
   c = str; 
   while(c) { 
      if(c) { 
         if(*c == sep) c++; 
         if(c) { 
            p = strchr(c, sep); 
            if(p) { 
               p[0] = '\0';    
               array[count] = (char *)strdup(c); 
               p[0] = sep; 
            } else { 
               array[count] = (char *)strdup(c); 
            } 
            count++; 
            array[count] = NULL; 
         } 
      } 
      c = strchr(c, sep); 
   } 
   return array; 
}